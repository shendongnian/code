    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                this.webBrowser1.Navigate("https://www.salesgenie.com/Account/LogOn");
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                string SomeUserName = "Test";
                string SomePassword = "Test";
    
                HtmlElement userName = webBrowser1.Document.GetElementById("username");
                Console.WriteLine(userName.GetAttribute("value"));
                userName.SetAttribute("value", SomeUserName);
                userName.RemoveFocus();
    
                HtmlElement password = webBrowser1.Document.GetElementById("password");
                Console.WriteLine(userName.GetAttribute("value"));
                password.SetAttribute("value", SomePassword);
    
                HtmlElement logonForm = webBrowser1.Document.GetElementById("logon-submit");
                logonForm.InvokeMember("click");
            }
        }
    }
