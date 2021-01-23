    var websiteIndex = 0;
    webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
    
    private void ProcessWebsite()
    {
    	if (websiteIndex < ALLWebSites.Count)
    	{
    		webBrowser1.Navigate(ALLWebSites[websiteIndex]);
    		websiteIndex++;
    	}
    }
    
     private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
    	//do work
    	
    	// when work is done, process next one
    	ProcessWebsite();
    }
