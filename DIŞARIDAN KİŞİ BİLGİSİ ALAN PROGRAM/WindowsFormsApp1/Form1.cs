using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("TC KİMLİK NO", 150);
            listView1.Columns.Add("ADI SOYADI", 200);
            listView1.Columns.Add("YAŞI", 50);
            listView1.Columns.Add("MEZUNİYET", 150);
            listView1.Columns.Add("CİNSİYET", 125);
            listView1.Columns.Add("DOĞUM YERİ", 125);
            listView1.Columns.Add("TELEFON NO", 130);
            kayitsayisiyaz();
        }

            private void kayitsayisiyaz()
            {
                int kayitsayisi = listView1.Items.Count;  // kayitsayisi kısmına listenin satır sayısını ekledik.(satır sayısı)
                label8.Text = Convert.ToString(kayitsayisi);
            }

        private void button2_Click(object sender, EventArgs e)
        {

            string tc = "", adsoyad = "", yas = "", mezuniyet = "", cinsiyet = "", dogumyeri = "", telefon = "";
            tc = textBox1.Text; adsoyad = textBox2.Text; yas = textBox3.Text; mezuniyet = comboBox1.Text;
            dogumyeri = textBox4.Text; telefon = textBox5.Text;
            if (radioButton1.Checked == true)
            {
                cinsiyet = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                cinsiyet = radioButton2.Text;
            }

            string[] bilgiler = { tc, adsoyad, yas, mezuniyet, cinsiyet, dogumyeri, telefon }; //bilgileri bir dizinin içine attık döngü yapabilmek için
            bool aranankayitkontolu = false;// bunu yapmamızın sebebi aynı girilen bir tc kimlik bilgisi varsa true değeri dönsün ve hata versin false olarak tanımladık hata yokmuş gibi

            for (int i = 0; i < listView1.Items.Count; i++) // items satır count miktar demek satır miktarını dongüye tuttuk.
            {  // for döngüsü yapmamızın sebebi tc kimlik ifadesinin döngüsünü oluşturmak(girilen ifadelerin döngüsü)

                if (listView1.Items[i].SubItems[0].Text == textBox1.Text)
                {
                    // bu if döngüsündeki amaç tc kimlik sütununu kontrol etmek için yazdık
                    // items ifadesi satır demek(bunu döngüye aldık i=0dan başladı) subitems ifadesi sütun demek her zaman tc sütünunu kontrol edecek biçimde
                    aranankayitkontolu = true;
                    MessageBox.Show(textBox1.Text + "tc kimlik numarası mevcut kayıt oluşturamazsınız");

                }
            }
            if (aranankayitkontolu == false) // eğer farklı bir tc ise
            {
                ListViewItem lst = new ListViewItem(bilgiler);  // yeni bir liste oluştururuz eğer tc önceki girilenlerden farklı ise
                if (tc != "" && adsoyad != "" && yas != "" && mezuniyet != "" && cinsiyet != "" && dogumyeri != "" && telefon != "")
                {
                    // bu if döngüsü eğer ifademizde boşluk yok ise işlenir 
                    // tüm ifadeler yazıldıysa listeyi bastırabiliriz
                    listView1.Items.Add(lst);
                }
                else
                {
                    MessageBox.Show("girdiğiniz bilgilerde eksiklik var");
                }
            }
            kayitsayisiyaz(); // kayitsayisini yazdırdığımız metodu yazdık

        }

        private void button3_Click(object sender, EventArgs e)
        {

            // biz listbox özelliğinden checbox seçeneğini true ifadesine çevirmiştik.
            //şimdide sil(checkbox ) ifadesi sayesinde satır ifadelere tıklanabilir seçenek olduğunda tıklayıp seçili ifadeyi silebiliyoruz

            int secilensayisi = listView1.CheckedItems.Count; // checbox sayesinde kaç tane kişi sayısı olduğunu tanımladık.

            foreach (ListViewItem secilikayitbilgisi in listView1.CheckedItems)
            {
                // döngü oluşturduk in (içindeki) yani checkboxtaki seçili kişilerin içinden seçilikayıtbilgisine döngü akar

                secilikayitbilgisi.Remove();// remove=kaldırmak  seçili kişileri bu döngü sayesinde kaldırdık.
            }
            MessageBox.Show(secilensayisi.ToString() + "adet kayıt silindi"); //silinen kayıt sayısını yazdırdık kullanıcıya
            kayitsayisiyaz();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // kayıdı silerek silmek için tüm ifadelerin çıkmasını istiyorsak listbox ayarlar kısmnında 
            // fullrowselect kısmını true yaparız

            int secilensayisi = listView1.SelectedItems.Count; //sil(checkbox) ile aynı gibi sadece burda seçtiğimiz için selected diye yaptık

            foreach (ListViewItem secilikayitbilgisi in listView1.SelectedItems)
            {
                secilikayitbilgisi.Remove();
            }
            MessageBox.Show(secilensayisi.ToString() + "adet kayıt silindi");
            kayitsayisiyaz();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            listView1.Items.Clear(); // tümünü sil butonu ile tümünü sildirdik
            kayitsayisiyaz();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ara butonuna kod yazıyoruz
            // listview nesnesinde item satır subitem sütun demek
            bool aranan_kayit_kontrolu = false;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[0].Text==textBox1.Text) 
                {  // girilen satır kadar bir döngü oluşturduk ve tc kimlik noları karşılaştırdık

                    aranan_kayit_kontrolu = true;
                    textBox2.Text = listView1.Items[i].SubItems[1].Text;
                    textBox3.Text = listView1.Items[i].SubItems[2].Text;
                    comboBox1.Text = listView1.Items[i].SubItems[3].Text;

                    if (listView1.Items[i].SubItems[4].Text=="erkek")
                    {
                        radioButton1.Checked = true;
                    }
                    else if (listView1.Items[i].SubItems[4].Text == "bayan")
                    {
                        radioButton2.Checked = true;
                    }

                    textBox4.Text = listView1.Items[i].SubItems[5].Text;
                    textBox5.Text = listView1.Items[i].SubItems[6].Text;

                    // kişiyi aradıktan sonra nesneleri kullanılamaz hale getiriyoruz
                    textBox2.Enabled = false; textBox3.Enabled = false; comboBox1.Enabled = false;
                    groupBox1.Enabled = false; textBox4.Enabled = false; textBox5.Enabled = false;

                }
            }

        }
    }
    }

