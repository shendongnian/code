    var proc = new ProcessWithData();
            proc.SetHandler(ProcOnExited);
            proc.StartInfo.FileName = "foo.exe";
            proc.EnableRaisingEvents = true;
            proc.Start();
    private void ProcOnExited(object sender, EventArgs e)
    {
        // do stuff
    }
