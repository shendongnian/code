    using System;
    using System.IO;
    using System.Windows.Forms;
    using Microsoft.VisualBasic.FileIO;
    public partial class Form1 : Form
    {
        // other code
        private void button1_Click(object sender, EventArgs e)
        {
            string sourceDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string destDir = Path.Combine(sourceDir, "xgen");
            string[] txtList =
                Directory.GetFiles(sourceDir, "*.txt");
            progressBar1.Value = 1;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = txtList.Length;
            try
            {
                foreach (string f in txtList)
                {
                    string fName = Path.GetFileName(f);   //f.Substring(sourceDir.Length + 1);
                    string destFile = Path.Combine(destDir, fName);
                    FileSystem.CopyFile(
                        f, destFile, UIOption.AllDialogs, UICancelOption.ThrowException);
                    progressBar1.PerformStep();
                }
            }
            catch (IOException copyerror)
            {
                MessageBox.Show(copyerror.Message);
            }
        }
    }
