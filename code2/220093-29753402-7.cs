    static void runCommand() {
        Process process = new Process();
        process.StartInfo.FileName = "cmd.exe";
        process.StartInfo.Arguments = "/c DIR"; // Note the /c command (*)
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.Start();
        //* Read the output (or the error)
        string output = process.StandardOutput.ReadToEnd();
        Console.WriteLine(output);
        string err = process.StandardError.ReadToEnd();
        Console.WriteLine(err);
        process.WaitForExit();
    }
