    _process.OutputDataReceived += Process_OutputDataReceived;
    _process.ErrorDataReceived += Process_ErrorDataReceived;
    void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        Console.WriteLine(e.Data);
    }
    void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
    {
        // do your stuff
    }
