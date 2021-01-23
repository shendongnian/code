    System.Diagnostics.Process proc = new System.Diagnostics.Process();
    proc.StartInfo.FileName = @"usbformat.bat";
    proc.StartInfo.UseShellExecute = false;
    proc.StartInfo.CreateNoWindow = true; // change to false to show the cmd window
    proc.Start();
    proc.WaitForExit();
    if (proc.ExitCode != 0)
       {
           return false;
       }
       else
       {
           return true;
       }
