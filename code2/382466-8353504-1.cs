    void RunProcess(string fileName, string arguments, BackgroundWorker worker)
    {
      // prep process
      ProcessStartInfo psi = new ProcessStartInfo(fileName, arguments);
      psi.UseShellExecute = false;
      psi.RedirectStandardOutput = true;
      psi.RedirectStandardError = true;
      // start process
      using (Process process = new Process())
      {
        // pass process data
        process.StartInfo = psi;
        // prep for multithreaded logging
        ProcessOutputHandler outputHandler = new ProcessOutputHandler(process,worker);
        Thread stdOutReader = new Thread(new ThreadStart(outputHandler.ReadStdOut));
        Thread stdErrReader = new Thread(new ThreadStart(outputHandler.ReadStdErr));
        // start process and stream readers
        process.Start();
        stdOutReader.Start();
        stdErrReader.Start();
        // wait for process to complete
        process.WaitForExit();
       }
    }
