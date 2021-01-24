    Process proc = new Process();
    proc.EnableRaisingEvents = false;
    proc.StartInfo.FileName = "cmd";
    proc.StartInfo.Arguments = @"/C pushd \\server\folder && copy *.txt.gz /b 
        combined.gz";
    proc.StartInfo.RedirectStandardOutput = true;
    proc.StartInfo.RedirectStandardError = true;
    proc.StartInfo.UseShellExecute = false;
    proc.Start();
    proc.WaitForExit();
    System.Threading.Thread.Sleep(2000);
    string line = proc.StandardOutput.ReadLine();
    while (line != null)
    {
        output.Append(line);
        line = proc.StandardOutput.ReadLine();
    }
