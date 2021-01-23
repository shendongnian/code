    public class LaunchCommandAsProcess
    {
    public delegate void OutputEventHandler(object sendingProcess, EventArgsForCommand e);
    public event OutputEventHandler OutputReceived;
    private StreamWriter stdIn;
    private Process p;
    public void SendCommand(string command)
    {
    stdIn.WriteLine(command);
    }
    public LaunchCommandAsProcess()
    {
    p = new Process();
    p.StartInfo.FileName = @"C:\Windows\System32\cmd.exe";
    p.StartInfo.UseShellExecute = false;
    p.StartInfo.RedirectStandardInput = true;
    p.StartInfo.RedirectStandardOutput = true;
    p.StartInfo.RedirectStandardError = true;
    p.StartInfo.CreateNoWindow = true;
    p.Start();
    
    stdIn = p.StandardInput;
    p.OutputDataReceived += Process_OutputDataReceived;
    p.ErrorDataReceived += Process_OutputDataReceived;
    p.BeginOutputReadLine();
    p.BeginErrorReadLine();
    
    }
    ///
    /// Raises events when output data has been received. Includes normal and error output.
    /// 
    
    /// /// private void Process_OutputDataReceived(object sendingProcess, DataReceivedEventArgs outLine)
    {
    if (outLine.Data == null)
    return;
    else
    {
    if (OutputReceived != null)
    {
    EventArgsForCommand e = new EventArgsForCommand();
    e.OutputData = outLine.Data;
    OutputReceived(this, e);
    }
    }
    }
    ///
    /// Synchronously closes the command promp.
    /// 
    
    public void SyncClose()
    {
    stdIn.WriteLine("exit");
    p.WaitForExit();
    p.Close();
    }
    ///
    /// Asynchronously closees the command prompt.
    /// 
    
    public void AsyncClose()
    {
    stdIn.WriteLine("exit");
    p.Close();
    }
    }
    public class EventArgsForCommand : EventArgs
    {
    public string OutputData { get; internal set; }
    }
