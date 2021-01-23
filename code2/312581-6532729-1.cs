    Process proc = new Process();
    proc.startInfo.FileName = "notepad.exe";
    proc.Exited += ProcessExited;
    proc.Start();
    private void ProcessExited(object sender, EventArgs e)
    {
        // notepad was closed
    }
