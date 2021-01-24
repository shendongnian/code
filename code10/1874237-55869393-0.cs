    using System.Diagnostics;
    Process proc = new Process();
    proc.StartInfo.FileName = "control.bat";
    if (proc.Start())
     {
     //All good!
     }
    else
     {
     //Oh no! it's not running!
     }
