      string result; 
      ProcessStartInfo info = new ProcessStartInfo() {
        UseShellExecute = false,
        CreateNoWindow = true,
        WindowStyle = ProcessWindowStyle.Hidden,
        RedirectStandardError = true,
        RedirectStandardOutput = true,
        Arguments = "1 2", // we pass 2 arguments: 1 and 2
        FileName = @"Myexe.exe",
      };
      using (Process process = new Process()) {
        process.StartInfo = info;
        process.Start();
        StringBuilder sbOut = new StringBuilder();
        StringBuilder sbErr = new StringBuilder();
        process.OutputDataReceived += (sender, e) => {
          if (e.Data != null) {
            sbOut.AppendLine(e.Data);
          }
        };
        process.ErrorDataReceived += (sender, e) => {
          if (e.Data != null)
            sbErr.AppendLine(e.Data);
        };
        process.BeginErrorReadLine();
        process.BeginOutputReadLine();
        // Let process complete its work
        process.WaitForExit();
        result = sbErr.Length > 0 
          ? sbErr.ToString()   // process failed, let's have a look at StdErr
          : sbOut.ToString();  // process suceeded, let's get StdOut
      }
      Console.WriteLine(result);
