    BackgroundWorker bg = new BackgroundWorker();
    bg.DoWork+=new DoWorkEventHandler(bg_DoWork);
    bg.RunWorkerAsync(5);
    
    static void  bg_DoWork(object sender, DoWorkEventArgs e)
    {
                int j = (int)e.Argument;
    }
