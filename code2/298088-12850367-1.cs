    void NotAccessibleError(FileSystemWatcher source, ErrorEventArgs e)
    {
        int iMaxAttempts = 120;
        int iTimeOut = 30000;
        int i = 0;
        while ((!Directory.Exists(source.Path) || fswWatchImages.EnableRaisingEvents == false) && i < iMaxAttempts)
        {
            i += 1;
            try
            {
                source.EnableRaisingEvents = false;
                if (!Directory.Exists(source.Path))
                {
                    MyEventLog.WriteEntry("Directory Inaccesible " + fswWatchImages.Path + " at " + DateTime.Now.ToString("HH:mm:ss"));
                    System.Threading.Thread.Sleep(iTimeOut);
                }
                if (Directory.Exists(source.Path))
                { 
                    // ReInitialize the Component
                    source.Dispose();
                    source = null;
                    source = new System.IO.FileSystemWatcher();
                    ((System.ComponentModel.ISupportInitialize)(source)).BeginInit();
                    source.EnableRaisingEvents = true;
                    source.Filter = "*.tif";
                    source.NotifyFilter = System.IO.NotifyFilters.FileName;
                    source.Created += new System.IO.FileSystemEventHandler(fswCatchImages_Changed);
                    source.Renamed += new System.IO.RenamedEventHandler(fswCatchImages_Renamed);
                    source.Error += new ErrorEventHandler(OnError);
                    ((System.ComponentModel.ISupportInitialize)(source)).EndInit();
                    MyEventLog.WriteEntry("Try to Restart RaisingEvents Watcher at " + DateTime.Now.ToString("HH:mm:ss"));
                }
            }
            catch (Exception error)
            {
                MyEventLog.WriteEntry("Error trying Restart Service " + error.StackTrace + " at " + DateTime.Now.ToString("HH:mm:ss"));
                source.EnableRaisingEvents = false;
                System.Threading.Thread.Sleep(iTimeOut);
            }
        }
    }
