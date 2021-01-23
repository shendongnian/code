    var StdOut = "";
    var StdErr = "";
    
    var stdout = new StringBuilder();
    var stderr = new StringBuilder();
    var psi = new ProcessStartInfo();
    psi.FileName = @"something.exe";
    psi.CreateNoWindow = true;
    psi.UseShellExecute = false;
    psi.RedirectStandardOutput = true;
    psi.RedirectStandardError = true;
    
    var proc = new Process();
    proc.StartInfo = psi;
    proc.OutputDataReceived += (sender, e) => { stdout.AppendLine(e.Data); };
    proc.ErrorDataReceived += (sender, e) => { stderr.AppendLine(e.Data); };
    proc.Start();
    proc.BeginOutputReadLine();
    proc.BeginErrorReadLine();
    proc.WaitForExit();
    StdOut = stdout.ToString();
    StdErr = stderr.ToString();
