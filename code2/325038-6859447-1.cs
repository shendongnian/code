    public void ThreadProc()
    {
        info.watch.Start();
        using (var proc = InstantiateProcess())
        {
            proc.Start();
            proc.BeginOutputReadLine();
            proc.WaitForExit();
        }
    }
