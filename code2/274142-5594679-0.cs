    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Xml.Linq;
    using System.Xml.XPath;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(txtUrl.Text);
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var rssDoc = XDocument.Load((string)e.Argument);
            var items = new List<ListViewItem>();
            foreach (var item in rssDoc.XPathSelectElements("//item"))
            {
                var listItem = new ListViewItem();
                listItem.Text = item.Element("title").Value;
                listItem.SubItems.Add(item.Element("link").Value);
                items.Add(listItem);
            }
            e.Result = items.ToArray();
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lstView.Items.AddRange((ListViewItem[])e.Result);
        }
    }
