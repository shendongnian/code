    public void MinimizeApp(string parameter)
    {
        if (parameter == "-minimized")
        {
            this.WindowState = FormWindowState.Minimized;
            notifyIcon1.Visible = true;
            notifyIcon1.BalloonTipText = "Program is started and running in the background...";
            notifyIcon1.ShowBalloonTip(500);
            Hide();
        }
        
    }
