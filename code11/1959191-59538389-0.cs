public delegate void UpdateData(string data);
**Step 2**: Declare a `event` in `Filecheck` `class` (`OnUpdateData`) with the `delegate` created:
public event UpdateData OnUpdateData;
**Step 3**: Raise the event anywhen you want:
this.OnUpdateData?.Invoke(line);
**Step 4**: In your `main` function, set `OnUpdateData` by:
Filecheck NewFileChecker = new Filecheck();
NewFileChecker.OnUpdateData += (d => MessageBox.Show(d));
Full code:
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApp1
{
    public delegate void UpdateData(string data);
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string path = @"C:\MyPath\";
            Filecheck NewFileChecker = new Filecheck();
            NewFileChecker.OnUpdateData += (d => MessageBox.Show(d));
            NewFileChecker.WatchingFile(path, "myFile.txt");
        }
    }
    class Filecheck
    {
        public event UpdateData OnUpdateData;
        public void WatchingFile(string FilePath, string Filter)
        {
            FileSystemWatcher fsw = new FileSystemWatcher();
            fsw.Path = FilePath;
            fsw.Filter = Filter;
            fsw.NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.LastWrite;
            fsw.Changed += OnFileChange;
            fsw.EnableRaisingEvents = true;
        }
        private void OnFileChange(object sender, FileSystemEventArgs e)
        {
            string line;
            try
            {
                using (FileStream file = new FileStream(e.FullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader sr = new StreamReader(file, Encoding.Default))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        //MessageBox.Show(line);
                        // I WOULD LIKE TO UPDATE A FORM1 RichTextBox from here....
                        this.OnUpdateData?.Invoke(line);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
