    using System;
    using System.IO;
    using System.Windows.Forms;
    
    namespace Udemyvericekme
    {
        public partial class opera : Form
        {
            public opera()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                string sourceDir = @"C:\Users\Ebubekir\Desktop\resimler\";
                string backupDir = @"C:\Users\Ebubekir\Desktop\bekrabackup\";
    
                try
                {
                    string[] picList = Directory.GetFiles(sourceDir, "*.png");
    
                    foreach (string f in picList)
                    {
    
                        string fName = f.Substring(sourceDir.Length + 1);
                        try
                        {
                            File.Copy(f, backupDir + "OUTPUT" + fName);
                        }
                        catch
                        {
                        }
                    }
    
                    foreach (string f in picList)
                    {
                        File.Delete(f);
                    }
                }
    
                catch (DirectoryNotFoundException dirNotFound)
                {
                    Console.WriteLine(dirNotFound.Message);
                }
            }
        }
    }
     File.Copy(f, backupDir + "OUTPUT" + fName);
