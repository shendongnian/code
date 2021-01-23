    void foo()
    {
        System.Diagnostics.Process p = new System.Diagnostics.Process();
        p.StartInfo.FileName = "c:\\windows\\system32\\ping.exe";
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.UseShellExecute = false;
        p.EnableRaisingEvents = true;
        p.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(p_OutputDataReceived);
        p.Start();
        p.BeginOutputReadLine();
    }           
    void p_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
    {
        string s = e.Data;        
        // process s
    }
