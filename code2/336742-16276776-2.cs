    var process = new Process();
    process.StartInfo.CreateNoWindow = true;
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.RedirectStandardOutput = true;
    process.StartInfo.RedirectStandardError = true;
    process.StartInfo.WorkingDirectory = @"C:\test\";
    process.StartInfo.FileName = "test.exe";
    process.StartInfo.Arguments = "your arguments here";
    process.Start();
    var output = new List<string>();
    
    while (process.StandardOutput.Peek() > -1)
    {
        output.Add(process.StandardOutput.ReadLine());
    }
    while (process.StandardError.Peek() > -1)
    {
        output.Add(process.StandardError.ReadLine());
    }
    process.WaitForExit();
