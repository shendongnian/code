    var proc = new ProcessWithData("foo.exe");
            proc.SetHandler(ProcOnExited);
            proc.EnableRaisingEvents = true;
            proc.Start();
    private void ProcOnExited(object sender, EventArgs e)
    {
        // do stuff
    }
