    string path = Path.Combine(Directory.GetCurrentDirectory(), "folderInDebug");
    var startInfo = new System.Diagnostics.ProcessStartInfo
    {
          WorkingDirectory = path,
          FileName = "cmd",
          Arguments = "/c sysdm.cpl",
          UseShellExecute = false
     };
     Process proc = Process.Start(startInfo);
