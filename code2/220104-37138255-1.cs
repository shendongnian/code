    static void runCommand()
    {
        //* Create your Process
        Process process = new Process();
        process.StartInfo.FileName = "cmd.exe";
        process.StartInfo.Arguments = "/c DIR";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        //* Set ONLY ONE handler here.
        process.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
        //* Start process
        process.Start();
        //* Read one element asynchronously
        process.BeginErrorReadLine();
        //* Read the other one synchronously
        string output = process.StandardOutput.ReadToEnd();
        Console.WriteLine(output);
        process.WaitForExit();
    }
    static void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine) 
    {
        //* Do your stuff with the output (write to console/log/StringBuilder)
        Console.WriteLine(outLine.Data);
    }
