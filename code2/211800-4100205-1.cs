    using (Process process = Process.Start(startInfo))
    {
        LogToTextFile(process.StandardOutput.ReadToEnd());
    
        if(process.WaitForExit(60000))
        {
            exitCode = process.ExitCode;
        }
        else
        {
            process.Kill();
        }
    }
