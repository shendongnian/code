    var SourcePath = args[0];  // URL link
    var startDate = args[1];
    var endDate = args[2];    
    
    var cmd1 = "cd c:\\";
    var cmd2 = string.Concat("svn log ", SourcePath, " -r {", startDate, "}:{", endDate, "}");
    
    ProcessStartInfo startInfo = new ProcessStartInfo();
    startInfo.FileName = "cmd.exe";
    startInfo.RedirectStandardInput = true;
    startInfo.RedirectStandardOutput = true;
    startInfo.RedirectStandardError = true;
    startInfo.UseShellExecute = false;
    Process process = new Process();
    process.StartInfo = startInfo;
        
    process.Start();
    process.StandardInput.WriteLine(cmd1);
    process.StandardInput.WriteLine(cmd2);
    // It's always a good idea to close your standard input when you're not gonna need it anymore,
    // otherwise the process will wait indefinitely for any input and your while condition will never
    // be true or in other words it will become an infinite loop...
    process.StandardInput.Close();
    
    string result = string.Empty; // for storing the svn commit log
    
    while (!process.StandardOutput.EndOfStream)
    {
        string line = process.StandardOutput.ReadLine();
        if (!string.IsNullOrEmpty(line))
        {
            if (!process.HasExited)
            {
                result += line + Environment.NewLine;
            }
        }                
    }
