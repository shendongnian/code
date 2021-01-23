    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace WebBrowserTest
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                this.webBrowser1.ObjectForScripting = new MyScript();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                webBrowser1.Navigate("http://localhost:6489/Default.aspx");
            }
    
            private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                webBrowser1.Navigate("javascript: window.external.CallServerSideCode();");
            }
    
            [ComVisible(true)]
            public class MyScript
            {
                public void CallServerSideCode()
                {
                    var doc = ((Form1)Application.OpenForms[0]).webBrowser1.Document;
                }
            }
        }
    }
