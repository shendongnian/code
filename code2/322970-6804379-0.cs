    public Form1()
    {
        InitializeComponents();
    
        _checkPixelsTimer.Intervla = 1000;//one second
        _checkPixelsTimer.AutoReset = true;
        _checkPixelsTimer.Elapced += OnCheckPixelsTimerElapced;
        _checkPixelsTimer.Start();
    }
    private void OnCheckPixelsTimerElapced(object sender, System.Timer.ElapcedEventArgs e)
    {
        ClassName.CheckScreen(CaptureScreen(),ClassName.Pxarr1);
    }
