    public void StartSplash()
    {
        Splash.Show();
        BackgroundWorker bgw = new BackgroundWorker();
        // set up bgw Delegates
        bgw.RunWorkerAsync();
    }
    
    public void bgw_DoWork( ... etc
    {
        // do stuff in background thread
        // you cannot touch the UI from here
    }
    
    public void bgw_RunWorkerCompleted( ... etc
    {
        Splash.close();
        // read data from background thread
        this.show();  // and other stuff
    }
