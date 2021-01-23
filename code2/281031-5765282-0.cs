    using System.IO;
    using System.Reflection;
    ...
            string myDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string gameDir = Path.Combine(myDir, "MBO");
            string gameExe = Path.Combine(gameDir, "marbleblast.exe");
            process1.StartInfo.FileName = gameExe;
            process1.StartInfo.WorkingDirectory = gameDir;
            process1.SynchronizingObject = this;
            process1.EnableRaisingEvents = true;
            process1.Exited += new EventHandler(Process1Exited);
