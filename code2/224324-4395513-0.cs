    Process[] processes = Process.GetProcesses();
    foreach (var proc in processes)
    {
       if (!string.IsNullOrEmpty(proc.MainWindowTitle))
            Console.WriteLine(proc.MainWindowTitle);
    }
