    System.Windows.Forms.WebBrowser _browser;
    System.Windows.Threading.DispatcherTimer _browserTestTimer;
    public void Browse()
    {
        _browser = new System.Windows.Forms.WebBrowser();
    
        _browser.DocumentCompleted += browser_DocumentCompleted;
    
        _browser.Navigate("http://address.com");
    
        _browserTestTimer = new System.Windows.Threading.DispatcherTimer();
        _browserTestTimer.Interval = TimeSpan.FromSeconds(0.5);
        _browserTestTimer.Tick += new EventHandler(browserTestTimer_Tick);
    }
    
    void browser_DocumentCompleted(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
    {
        if (_browser.ReadyState == System.Windows.Forms.WebBrowserReadyState.Complete)
        {     
            _browserTestTimer.Start();
        }
    }
    
    private void browserTestTimer_Tick(object sender, EventArgs e)
    {
        string strSource = _browser.Document.GetElementsByTagName("HTML")[0].OuterHtml;
        
        if (strSource.Contains("something added from javascript"))
        {
            _browserTestTimer.Stop();
                        
            //Success - do stuff as a result
        }
    }
