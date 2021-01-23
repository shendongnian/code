    EventWaitHandle _waitHandle = new AutoResetEvent(false);
    public static void ShowSplashScreen()
    {
        using(SplashForm splashForm = new SplashForm())
        {
            splashForm.Show();
            _waitHandle.WaitOne();
            splashForm.Close();
        }
    }
    //Called in MainForm_Load()
    public static void CloseSplashScreen()
    {
        _waitHandle.Set();
    }
