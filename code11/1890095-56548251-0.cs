    static void Main()
    {
        var commands = new List<string>() { "dir", "mkdir ABC", "dir" };
        ExecuteCmd(commands);
        Console.ReadLine();
    }
    static void ExecuteCmd(List<string> commands)
    {
        Process p = new Process();
        p.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
        p.StartInfo.FileName = "cmd.exe";
        p.StartInfo.CreateNoWindow = true;
        p.StartInfo.RedirectStandardInput = true;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.UseShellExecute = false;
        p.Start();
        foreach (var comm in commands)
            p.StandardInput.WriteLine(comm);
        p.StandardInput.Flush();
        p.StandardInput.Close();
        p.WaitForExit();
        Console.WriteLine(p.StandardOutput.ReadToEnd());
    }
