    private void Go(string url)
    {
        webBrowser1.Navigate(url);
        webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
    }
    
    void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        webBrowser1.Document.Click += new HtmlElementEventHandler(Document_Click);
    }
    
    void Document_Click(object sender, HtmlElementEventArgs e)
    {
        HtmlElement ele = webBrowser1.Document.GetElementFromPoint(e.MousePosition);
        while (ele != null)
        {
            if (ele.TagName.ToLower() == "a")
            {
                // METHOD-1
                // Use the url to open a new tab
                string url = ele.GetAttribute("href");
                // TODO: open the new tab
                e.ReturnValue = false;
    
                // METHOD-2
                // Use this to make it navigate to the new URL on the current browser/tab
                ele.SetAttribute("target", "_self");
            }
            ele = ele.Parent;
        }
    }
