        using System.Threading;
        ...
        string[] drives = Environment.GetLogicalDrives();
        List<Thread> threads = new List<Thread>();
        foreach (string drive in drives)
        {
            if (GetDriveType(drive).ToString().CompareTo("DRIVE_FIXED") == 0)
            {
                DriveInfo driveInfo = new DriveInfo(drive);
                if (driveInfo.IsReady)
                {
                    System.IO.DirectoryInfo rootDirectory = driveInfo.RootDirectory;
                    var thread = new Thread((dir) => RecursiveFileSearch((DirectoryInfo)dir));
                    threads.Add(thread);
                    thread.Start(rootDirectory);
                }
            }
        }
        foreach(var t in threads) t.Join();
        MessageBox.Show(files.Count.ToString());
