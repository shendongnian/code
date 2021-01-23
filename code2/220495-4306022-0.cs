    using System;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    
    class Test
    {
        [STAThread]
        static void Main()
        {
            Form form = new Form();
            WebBrowser browser = new WebBrowser();
            browser.Dock = DockStyle.Fill;
            form.Controls.Add(browser);
            form.Load += delegate { SetDocumentStream(browser); };
            
            Application.Run(form);
        }
        
        static void SetDocumentStream(WebBrowser browser)
        {
            string text = "<html><head><title>Stuff</title></head>" +
                "<body><h1>Hello</h1></body></html>";
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            MemoryStream ms = new MemoryStream();
            ms.Write(bytes, 0, bytes.Length);
            ms.Position = 0;
            browser.DocumentStream = ms;
        }
    }
