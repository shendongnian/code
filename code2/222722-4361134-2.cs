    Semaphore semX = new Semaphore(5, int.MaxValue);
    void f(name, args) {
        using (Process p = new Process())
        {
            p.StartInfo.FileName = name;
            p.StartInfo.Arguments = args;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();
            p.WaitForExit();
        }
        semX.Release();     // !!! This one is important
    }
