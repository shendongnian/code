        public void HTMLScreenShot()
        {
	        WebBrowser wb = new WebBrowser();
	        wb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wb_DocumentCompleted);
	        wb.Size = new Size(800, 600);
	
	        // Add html as string
	        wb.Navigate("about:blank");
	        wb.Document.Write("<b>Hellow World!</b>");
	        // Add html from website
	        // wb.Navigate("http://myurl.com");
	
        }
        void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
	        WebBrowser wb = sender as WebBrowser;
	        using (Bitmap bitmap = new Bitmap(wb.Width, wb.Height))
	        {
		        Rectangle bounds = new Rectangle(new Point(0, 0), wb.Size);
		        wb.DrawToBitmap(bitmap, bounds);
		        bitmap.Save("C:\WebsiteScreenshot.png");
	        }
        }
