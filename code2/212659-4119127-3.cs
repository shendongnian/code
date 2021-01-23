    static void Main(string[] args)
    {
      // Wire up the event handler for the ProcessClosed event
      ProcessMonitor.ProcessClosed += new EventHandler((s,e) =>
      {
        Console.WriteLine("Process Closed");
      });
      Process[] processes = Process.GetProcessesByName("notepad");
      if (processes.Length > 0)
      {
        ProcessMonitor.MonitorForExit(processes[0]);
      }
      else
      {
        Console.WriteLine("Process not running");        
      }
      Console.ReadKey(true);
    }
