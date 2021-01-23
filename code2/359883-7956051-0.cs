    WebBrowserDocumentCompletedEventArgs cachedLoadArgs;
    
    private void TimerDone(object sender, EventArgs e)
    {
        ((Timer)sender).Stop();
        respondToPageLoaded(cachedLoadArgs);
    }
    
    void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        cachedLoadArgs = e;
    
        System.Windows.Forms.Timer timer = new Timer();
    
        int interval = 1000;
    
        timer.Interval = interval;
        timer.Tick += new EventHandler(TimerDone);
        timer.Start();
    }
