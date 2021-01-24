        public static void CreateImageFromHTML(string sourceHtml, string imageFileName, int width, int height)
        {
            var th = new Thread(() =>
            {
                var webBrowser = new WebBrowser();
                webBrowser.Width = width;
                webBrowser.Height = height;
                webBrowser.ScrollBarsEnabled = false;
                webBrowser.DocumentCompleted += delegate (object sender, WebBrowserDocumentCompletedEventArgs e)
                {
                    webBrowser_DocumentCompleted(sender, e, imageFileName);
                };
                webBrowser.DocumentText = sourceHtml;
                Application.Run();
                webBrowser = null;
                GC.Collect();
            });
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            th.Join(4000);
        }
        static void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e, string fileName)
        {
            var webBrowser = (WebBrowser)sender;
            webBrowser.Dock = DockStyle.Fill;
            int height = webBrowser.Document.Body.ScrollRectangle.Height;
            int width= webBrowser.Document.Body.ScrollRectangle.Width;
            using (Bitmap bitmap = new Bitmap(width, height))
            {
                webBrowser.DrawToBitmap(bitmap, new Rectangle(0, 0, width, height));
                bitmap.Save(fileName, ImageFormat.Jpeg);
            }
        }
