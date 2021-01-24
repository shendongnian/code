    using System;
    using System.Windows.Forms;
    using Gecko;
    
    namespace Test
    {
        public partial class Frm1 : Form
        {
    
            public Frm1()
            {
                InitializeComponent();
    
                Xpcom.Initialize("Firefox64");
            }
            private void Frm1_Load(object sender, EventArgs e)
            {
                FormBorderStyle = FormBorderStyle.None;
    
                geckoWebBrowser1.Navigate("start\\test.html");
    			AddMessageEventListener("openFiles", showMessage);
            }
    		
    		
            public void AddMessageEventListener(string eventName, Action<string> action)
            {
                geckoWebBrowser1.AddMessageEventListener(eventName, action);
            }
    		
    		private void showMessage(string s)
            {
                var ofd = new OpenFileDialog { Filter = @"PDF |*.pdf", Title = @"Select a PDF file..." };
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show(ofd.FileName);
                }
    
            }
        }
    }
