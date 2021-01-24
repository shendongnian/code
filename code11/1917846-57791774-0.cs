    protected void SingleInstanceStartup(object sender, StartupEventArgs e)
    {
       Process[] tbPro = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
       foreach(Process p in tbPro)
       {
           if(p.Id != Process.GetCurrentProcess().Id)
           {
               p.Kill();
           }
        }
        myLog.Log("Création du mutex", LogType.Debug);
        _mutex = new Mutex(true, _applicationUniqueName);
        _args = e.Args;
        var mw = new MainWindow();
        mw.Closing += mainWindow_Closing;
        mw.Loaded += mainWindow_Loaded;
        myLog.Log("Lancement du serveur de named pipe", LogType.Debug);
        Server(_applicationUniqueName, mw);
        mw.Show();
    }
