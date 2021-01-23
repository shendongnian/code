    //I set Timer's interval to "250", it's personal
    //Just don't forget to enable the timer
    private void timer1_Tick(object sender, EventArgs e)
    {
        var self = Process.GetCurrentProcess();
        foreach (var proc in Process.GetProcessesByName(self.ProcessName))
        {
            if (proc.Id != self.Id)
            {
                proc.Kill();
            }
        }
    }
