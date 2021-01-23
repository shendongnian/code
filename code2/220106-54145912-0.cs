    ProcessStartInfo pinfo = new ProcessStartInfo(item);
    pinfo.CreateNoWindow = false;
    pinfo.UseShellExecute = true;
    pinfo.RedirectStandardOutput = true;
    pinfo.RedirectStandardInput = true;
    pinfo.RedirectStandardError = true;
    pinfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
    var p = Process.Start(pinfo);
    p.WaitForExit();
    Process process = Process.Start(new ProcessStartInfo((item + '>' + item + ".txt"))
    {
    	UseShellExecute = false,
    	RedirectStandardOutput = true
    });
    process.WaitForExit();
    string output = process.StandardOutput.ReadToEnd();
    if (process.ExitCode != 0) { 
    }
