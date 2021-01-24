    using System;
    using System.Diagnostics;
    using System.Linq;  
 
    Process[] processlist = Process.GetProcesses();
    var processTitle = processlist.Where(c => !string.IsNullOrEmpty(c.MainWindowTitle)).Select(c => c.MainWindowTitle).ToList();
