    using(Process proc = CreateProcess())
    {
        StartProcess(proc);
        if (!proc.WaitForExit(timeout))
        {
            proc.Kill();
        }
    }
