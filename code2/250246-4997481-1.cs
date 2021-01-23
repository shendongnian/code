    var proc = new System.Diagnostics.Process();
    proc.EnableRaisingEvents=false;
    proc.StartInfo.FileName="vsperfcmd";
    proc.StartInfo.Arguments="/start:coverage /output:run.coverage";
    proc.Start();
    proc.WaitForExit();
    
    var proc2 = new System.Diagnostics.Process();
    proc2.EnableRaisingEvents=false;
    proc2.StartInfo.FileName="hello";
    proc2.StartInfo.Arguments="";
    proc2.Start();
    proc2.WaitForExit();
    var proc3 = new System.Diagnostics.Process();
    proc3.EnableRaisingEvents=false;
    proc3.StartInfo.FileName="vsperfcmd";
    proc3.StartInfo.Arguments="/shutdown";
    proc3.Start();
    proc3.WaitForExit();
