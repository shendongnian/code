    private Queue<string> downloadQueue = new Queue<string>();
    public void ProcessSites()
    {
        foreach (string siteList in StaticStringClass.URLList)
            downloadQueue.Enqueue(siteList);
        webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
        if (downloadQueue.Count > 0)
        {
            string nextSite = downloadQueue.Dequeue();
            webBrowser1.Navigate(nextSite);
        }
    }
    void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        //other processing here
        if(downloadQueue.Count > 0)
        {
            string nextSite = downloadQueue.Dequeue();
            webBrowser1.Navigate(nextSite);
        }
    }
