    class Program
    {
    static void Main(string[] args)
    {
    LaunchCommandAsProcess cmd = new LaunchCommandAsProcess();
    cmd.OutputReceived += new LaunchCommandAsProcess.OutputEventHandler(launch_OutputReceived);
    cmd.SendCommand("help");
    cmd.SendCommand("ipconfig");
    cmd.SyncClose();
    }
    /// Outputs normal and error output from the command prompt.
    static void launch_OutputReceived(object sendingProcess, EventArgsForCommand e)
    {
    Console.WriteLine(e.OutputData);
    }
    }
