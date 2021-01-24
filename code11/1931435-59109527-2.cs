    public void SaveImage(string imageUrl, string filename, ImageFormat format)
    {
        System.Net.WebClient client = new WebClient();
        System.IO.Stream stream = client.OpenRead(imageUrl);
        Bitmap bitmap; bitmap = new Bitmap(stream);
        if (bitmap != null)
        {
            bitmap.Save(filename, format);
        }
        stream.Flush();
        stream.Close();
        client.Dispose();
    }
    public bool OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
    {
        if (commandId == (CefMenuCommand)26501)
        {
            browser.GetHost().ShowDevTools();
            return true;
        }
        if (commandId == (CefMenuCommand)26502)
        {
            browser.GetHost().CloseDevTools();
            return true;
        }
        if (commandId == (CefMenuCommand)113) // Copy
        {
            if (parameters.LinkUrl.Length > 0)
            {
                Clipboard.SetText(parameters.LinkUrl);
            }
            if (parameters.MediaType == ContextMenuMediaType.Image )
            {
                Clipboard.SetText(parameters.SourceUrl);
            }
        }
        if (commandId == (CefMenuCommand)26503) // Open in paintbrush
        {
            if (parameters.LinkUrl.Length > 0) {
                Clipboard.SetText(parameters.LinkUrl);
            }
            if (parameters.MediaType == ContextMenuMediaType.Image)
            {
                Clipboard.SetText(parameters.SourceUrl);
                string subPath = @"C:\temp";
                string fn = @"C:\temp\temp.bmp";
                System.IO.Directory.CreateDirectory(subPath);
                SaveImage(parameters.SourceUrl, fn, ImageFormat.Bmp);
                Process.Start(fn);
            }
        }
        // React to the third ID (Display alert message)
        if (commandId == (CefMenuCommand)26503)
        {
            MessageBox.Show("An example alert message ?");
            return true;
        }
        // Any new item should be handled through a new if statement
        // Return false should ignore the selected option of the user !
        return false;
    }
