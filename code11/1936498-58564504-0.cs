    public static Boolean BuildNpm()
    {
        Console.WriteLine("start process method?");
        var proc = new System.Diagnostics.Process();
        proc.StartInfo.WorkingDirectory="../../frontend/";
        proc.StartInfo.FileName = "/path/to/npm";
        proc.StartInfo.Arguments = "install";
        proc.Start();
        proc.WaitForExit();
        proc.StartInfo.Arguments = "run build";
        Console.WriteLine("Done?");
        return (proc.ExitCode == 0) ? true : false;
    }
