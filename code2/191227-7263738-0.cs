    // Set this to your output window Pane
    private EnvDTE.OutputWindowPane _OutputPane = null;
    // Methods to receive standard output and standard error
    private static void StandardOutputReceiver(object sendingProcess, DataReceivedEventArgs outLine)
    {
       // Receives the child process' standard output
       if (! string.IsNullOrEmpty(outLine.Data)) {
           if (_OutputPane != null)
               _OutputPane.Write(outLine.Data + Environment.NewLine);
       }
    }
    private static void StandardErrorReceiver(object sendingProcess, DataReceivedEventArgs errLine)
    {
       // Receives the child process' standard error
       if (! string.IsNullOrEmpty(errLine.Data)) {
           if (_OutputPane != null)
               _OutputPane.Write("Error> " + errLine.Data + Environment.NewLine);
       }
    }
    // main code fragment
    {
        // Start the new process
        ProcessStartInfo startInfo = new ProcessStartInfo(PROGRAM.EXE);
        startInfo.Arguments = COMMANDLINE;
        startInfo.WorkingDirectory = srcDir;
        startInfo.UseShellExecute = false;
        startInfo.RedirectStandardOutput = true;
        startInfo.RedirectStandardError = true;
        startInfo.CreateNoWindow = true;
        Process p = Process.Start(startInfo);
        p.OutputDataReceived += new DataReceivedEventHandler(StandardOutputReceiver);
        p.BeginOutputReadLine();
        p.ErrorDataReceived += new DataReceivedEventHandler(StandardErrorReceiver);
        p.BeginErrorReadLine();
        bool completed = p.WaitForExit(20000);
        if (!completed)
        {
            // do something here if it didn't finish in 20 seconds
        }
        p.Close();
    }
