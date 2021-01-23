    using System.Diagnostics;
    
    private void KillAllProcesses( string name )
    {
        Process[] processes = Process.GetProcessesByName( name );
        foreach( Process p in processes )
            p.Kill();
    }
