    using System;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();           
            }
    
            private void buttonDeleteRundomFile_Click(object sender, EventArgs e)
            {
                // Put all file names in a directory into array.
                string[] array1 = Directory.GetFiles(@"C:\Users\User\Desktop\test");
    
                // get a random file
                Random rnd = new Random();
                string fileName2Delete = array1[rnd.Next(1, array1.Count())];
    
                //delete that file
                File.Delete(fileName2Delete);
            }
        }
    }
