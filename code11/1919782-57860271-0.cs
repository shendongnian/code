    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.IO;
    
    namespace ListBox_57860008
    {
        public partial class Form1 : Form
        {
            BindingList<FileInfo> lstbx_DataSource = new BindingList<FileInfo>();
            public Form1()
            {
                InitializeComponent();
                listBox1.DataSource = lstbx_DataSource;
                listBox1.DisplayMember = "Name";
                listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
                fillDataSource();
            }
    
            private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                textBox1.Text = File.ReadAllText(((FileInfo)listBox1.SelectedItem).FullName);
            }
    
            private void fillDataSource()
            {
                foreach (string item in Directory.GetFileSystemEntries("c:\\temp\\", "*.txt"))
                {
                    lstbx_DataSource.Add(new FileInfo(item));
                }
            }
        }
    }
