    Most of the methods won't work for me on more than one web browser. This method is work with any amount of web browsers;
    
    1. Put web browser into a panel and set panel enabled to false, then navigate;
    
        webBrowser.Parent = panelBottom;
        panelWebBrowser.Enabled = false;
        webBrowser.Navigate("http://www.google.com");
    
    2. Define a navigated event to web browser and delay panels enabling for a second;
    
        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
        	System.Threading.Timer timer = null;
        	timer = new System.Threading.Timer((obj) =>
        	{
        		panelWebBrowser.Enabled = true;
        		timer.Dispose();
        	},null, 1000, Timeout.Infinite);
        }
