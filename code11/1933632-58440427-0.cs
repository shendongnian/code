    private void ScanpXRF()
    {
       counter = 0;
       timer = new System.Windows.Forms.Timer();
       timer.Interval = 1000;
       timer.Tick += RunEvent;
       timer.Start();
    }
