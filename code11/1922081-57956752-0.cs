    void Method()
    {
        var startInfo = new ProcessStartInfo()
        {
            FileName = ...,
            Arguments = ...,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false
        };
        
        var process = new Process()
        {
            StartInfo = startInfo
        };
        
        process.OutputDataReceived += ProcessOutputHandler;
        process.ErrorDataReceived += ProcessOutputHandler;
        
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
    }
        
    private void OnProcessOutputReceived(object sender, DataReceivedEventArgs e)
    {
        OutputMessage(e.Data);
    }
