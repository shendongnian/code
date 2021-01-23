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
        if (ClassName.CheckScreen(CaptureScreen(),ClassName.Pxarr1))
        {
            MethodInvoker method = new MethodInvoker(() => { /*code that relays on the UI thread */ });
            if (this.InvokeRequired)
            {
                this.Invoke(method); 
            }
            else
            {
                method();
            }
        }
    }
