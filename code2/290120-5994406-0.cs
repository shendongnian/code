    private int CallSomething()
    {
        using ( var p = new Process() )
        {
            p.StartInfo = new ProcessStartInfo("RegSvr32");
            p.Start();
    
            p.WaitForExit();
    
            return p.ExitCode;
        }
    }
