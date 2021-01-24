    bool running = false;
    private void button1_click(object sender, EventArgs e)
    {
        if (running)
        {
            var processes = Process.GetProcesses();
            
            foreach (Process pr in processes)
            {
            
                if (pr.ProcessName == "TeamViwer")
                {
                    pr.Kill();
                }
            
            }
           running = false;
        }
        else
        {
            Process proc = new Process();
            proc.StartInfo.FileName = @"C:\Program Files (x86)\TeamViewer\TeamViwer.exe";
            proc.Start();
            running = true;
        }
    }
