    using System;
    using System.Diagnostics;
    using System.Linq;  
    
    //will only get process with main window title property that is not empty
 
    Process[] processlist = Process.GetProcesses();
    var processTitle = processlist.Where(c => !string.IsNullOrEmpty(c.MainWindowTitle)).Select(c => c.MainWindowTitle).ToList();
