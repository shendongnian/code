    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.ServiceModel.Syndication;
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
            var reader = new XmlTextReader((string)e.Argument);
            var feed = SyndicationFeed.Load(reader);
            var items = new List<ListViewItem>();
            foreach (var item in feed.Items)
            {
                var listItem = new ListViewItem();
                listItem.Text = item.Title;
                foreach (var link in item.Links)
                {
                    listItem.SubItems.Add(link.Uri.AbsoluteUri);
                }
                items.Add(listItem);
            }
            e.Result = items.ToArray();
        }
    
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lstView.Items.AddRange((ListViewItem[])e.Result);
        }
    }
