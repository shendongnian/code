    using (Process proc = Process.Start(start))
    {
        string exitMsg = proc.StandardOutput.ReadToEnd();
        proc.WaitForExit(4000);
        int exitCode = proc.ExitCode;
    }
