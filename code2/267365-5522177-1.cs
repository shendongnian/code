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
             WebBrowser1.Url = new Uri("http://maps.google.com");
        }
        Stack< String> History = new Stack<String>();
        private void WebBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
                TextBox1.Text = e.Url.ToString();
                History.Push(e.Url.ToString());
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if(WebBrowser1.CanGoBack) 
            {
                WebBrowser1.GoBack();
            }
        
        }
  
    }
    }
