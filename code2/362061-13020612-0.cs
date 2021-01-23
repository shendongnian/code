    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using NDde.Client;
    
    namespace WindowsFormsApplication9
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                timer1.Enabled = true;
            }
    
            private string GetBrowserURL(string browser)
            {
                try
                {
                    DdeClient dde = new DdeClient(browser, "WWW_GetWindowInfo");
                    dde.Connect();
                    string url = dde.Request("URL", int.MaxValue);
                    string[] text = url.Split(new string[] { "\",\"" }, StringSplitOptions.RemoveEmptyEntries);
                    dde.Disconnect();
                    return text[0].Substring(1);
                }
                catch
                {
                    return null;
                }
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                int j=0;
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    if (listBox1.Items[i].ToString() == GetBrowserURL("Firefox"))
                    {
                        break;
                    }
                    else
                    {
                        j++;
                    }
                }
                if (j == listBox1.Items.Count)
                {
                    listBox1.Items.Add(GetBrowserURL("Firefox"));
                }
            }
        }
    }
