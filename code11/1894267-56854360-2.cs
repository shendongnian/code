    private Process process;
    private void EnsureProcessStarted()
    {
        if (null != process)
            return;
        
        var psi = new ProcessStartInfo
                  {
                      FileName = "cscript",
                      RedirectStandardError = true,
                      RedirectStandardOutput = true,
                      RedirectStandardInput = true,
                      UseShellExecute = false,
                      //CreateNoWindow = true,
                      WindowStyle = ProcessWindowStyle.Normal,
                      Arguments = "//nologo ask_SO.vbs"
                  };
        process = Process.Start(psi);
        process.OutputDataReceived += (s, args) => AppendLineToTextBox(args.Data);
        
        process.BeginOutputReadLine();
        
        // time to warm up
        Thread.Sleep(500);
    }
    private void AppendLineToTextBox(string line)
    {
        if (string.IsNullOrEmpty(line))
            return;
        
        if (output.InvokeRequired)
        {
            output.Invoke(new Action<string>(AppendLineToTextBox), line);
            return;
        }
        
        output.AppendText(line);
        output.AppendText(Environment.NewLine);
    }
    private void SendLineToProcess(string text)
    {
        EnsureProcessStarted();
        if (string.IsNullOrWhiteSpace(text))
        {
            process.StandardInput.Flush();
            process.StandardInput.Close();
            //process.WaitForExit(); causes a deadlock
            process = null;
        }
        else
        {
            AppendLineToTextBox(text); // local echo
            process.StandardInput.WriteLine(text);
            process.StandardInput.Flush();
            // time to process
            Thread.Sleep(50);
        }
    }
