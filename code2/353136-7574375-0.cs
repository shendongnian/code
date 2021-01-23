    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            //Fields
            public List<string> itemTexts;
    
            public Form1()
            {
                InitializeComponent();
    
                //Generate some items
                for (int i = 0; i < 10; i++)
                {
                    ListViewItem item = new ListViewItem();
    
                    item.Text = "item number #" + i;
    
                    listView1.Items.Add(item);
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.Checked)
                    {
                        itemTexts.Add(item.Text);
                    }
                }
    
                Form2 TextBoxForm = new Form2(itemTexts);
                TextBoxForm.Show();
            }
    
    
        }
    }
