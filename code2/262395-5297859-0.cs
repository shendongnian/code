    bool logFull = false;
    EventLog e = ... // get the needed event log
    var sizeKB = e.MaximumKilobytes; // event log size
    // Check current event log size
    var regEntry = Rgistry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\EventLog\\" + e.Log);
    if (regEntry != null)
    {
      var filePath = regEntry.GetValue("File");
      if (filePath != null)
      {
          var file = new FileInfo(filePath.ToString());
          if (file.Exists)
          {
             var fileSize = (file.Length + 1023) / 1024;
             logFull = (fileSize >= sizeKB); // a 1K margin
          }
       }
    }
