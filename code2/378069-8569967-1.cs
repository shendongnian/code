    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    namespace ImageEncodedInBase64InAWebBrowser
    {
        [ComVisible(true)]
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                string url = Directory.GetCurrentDirectory() + "\\page.html";
                webBrowser1.Url = new Uri(url);
                webBrowser1.ObjectForScripting = this;
            }
            private void button1_Click(object sender, EventArgs e)
            {
                string imageInBase64 = ReadImageInBase64();
                webBrowser1.Document.InvokeScript("setImageData", new[] { imageInBase64 });
            }
            private string ReadImageInBase64()
            {
                string imagePath = Directory.GetCurrentDirectory() + "\\opensource.png";
                using (var fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    var buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, (int)fs.Length);
                    return Convert.ToBase64String(buffer);
                }
            }
        }
    }
