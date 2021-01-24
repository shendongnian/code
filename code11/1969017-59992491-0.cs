    string path = @"C:\Program Files\Python";
    string args = "main.py";
    ProcessStartInfo pinfo = new ProcessStartInfo(path);
    pinfo.Arguments = args;
    using(Process proc = Process.Start(pinfo))
    {
        proc.WaitForExit();
        if(proc.ExitCode == 0)
        {
            // Normal exit
        }
        else
        {
            // Exit with error
        }
    }
