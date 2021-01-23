    Process[] processes = Process.GetProcessesByName("notepad");
    var ids = processes.Select(p => p.Id);
    foreach(int processId in ids)
    {
       // Do something with each processId
    }
