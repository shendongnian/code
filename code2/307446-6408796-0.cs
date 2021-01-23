    System.Diagnostics.Process proc = new System.Diagnostics.Process();
    string sOutput = "";
    proc.EnableRaisingEvents = false;
    proc.StartInfo.FileName = "php.exe";
    proc.StartInfo.Arguments = "-f file.php";
    proc.StartInfo.RedirectStandardOutput = true;
    System.IO.StreamReader hOutput = proc.StandardOutput;
    proc.WaitForExit(2000);
    if(proc.HasExited)
       sOutput = hOutput.ReadToEnd();           
