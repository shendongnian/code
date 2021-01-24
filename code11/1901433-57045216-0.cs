    using System;
    using System.IO;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp
    {
        public class ListViewDemo : Form
        {
            public ListViewDemo()
            {
                var _listView1 = new ListView();
    
                string[] files = { @"C:\tmp\file1.txt", @"c:\path\to\file2.doc" };
                foreach (string fi in files)
                {
                    string fnameonly = Path.GetFileNameWithoutExtension(fi);
                    _listView1.Items.Add(fnameonly);
                }
    
                AutoSize = true;
                Controls.Add(_listView1);    
            }
        }
    
        static class Program
        {    
            [STAThread]
            static void Main()
            {
                Application.Run(new ListViewDemo());
            }
        }
    }
