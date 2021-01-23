    private int n = 0;
    private void StartAProcess()
    {
        Process process = new Process {
            StartInfo = {FileName = "cmd.exe", Arguments = "pause"}, 
            EnableRaisingEvents = true};
        process.Exited += process_Exited;
        process.Start();
        n++;
    }
    void process_Exited(object sender, EventArgs e)
    {
        if (n < 3) StartAProcess();
    }
