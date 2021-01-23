    protected override void OnStart(string[] args)
    {
        BackgroundWorker bw = new BackgroundWorker();
        bw.DoWork += new DoWorkEventHandler(bw_DoWork);
        bw.RunWorkerAsync();
    }
    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        Process p = new Process();
        p.StartInfo = new ProcessStartInfo("file.exe");
        p.Start();
        p.WaitForExit();
        base.Stop();
    }
