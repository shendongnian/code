public class ExternalProcessMonitor
{
    Process process;
    Action action;
    string name;
    public ExternalProcessMonitor(string _name, Action _action)
    {
        action = _action;
        name = _name;
    }
    public bool StartMonitor()
    {
        if (process != null)
            process.Exited -= Process_Exited;
        var list = Process.GetProcesses().OrderBy(r => r.ProcessName);
        process = Process.GetProcessesByName(name).FirstOrDefault();
        if (process != null)
        {
            process.Exited += Process_Exited;
            process.EnableRaisingEvents = true;
        }
        return process != null;
    }
    private void Process_Exited(object sender, EventArgs e)
    {
        action();
    }
}
