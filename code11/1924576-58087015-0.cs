    EventLog eLog = new EventLog();
    eLog.Log = "Application"; //MsiInstaller events are written in Application
    eLog.EntryWritten += Log_NewInstallUninstallOccured; //Add the event and remove it when you want to stop listening
    eLog.EnableRaisingEvents = true; // Enable event raising
    
    private void Log_NewInstallUninstallOccured(object sender, EntryWrittenEventArgs e)
            {
                if (e.Entry.Source == "MsiInstaller") //MsiInstaller is the source responsible for installation related events
                {
                    if(e.Entry.Message.Contains("Installation completed successfully."))
                    {
                        Console.WriteLine("Installation Occured");
                    }
                    else if (e.Entry.Message.Contains("Removal completed successfully."))
                    {
                        Console.WriteLine("Removal Occured");
                    } else
                    {
                        Console.WriteLine("Other Installation Event Occured");
                    }
                }
            }
