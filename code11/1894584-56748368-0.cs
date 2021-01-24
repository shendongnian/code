    private string RunProcess(string command, string args)
    {
        StringBuilder sb = new StringBuilder();
        Process p = new Process();
        p.StartInfo.FileName = command;
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.CreateNoWindow = true;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.Arguments = args;
        p.OutputDataReceived += (sender, eventArgs) => { sb.Append(eventArgs.Data); };
        p.Start();
        p.WaitForExit();
        return sb.ToString();
    }
