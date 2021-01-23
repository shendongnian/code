    Microsoft.SqlServer.Management.Smo.Server smoServer = 
         new Server(new ServerConnection(server));
    
    Database db = smoServer.Databases['MyDataBase'];
    string dbPath = Path.Combine(db.PrimaryFilePath, 'MyDataBase.mdf');
    string logPath = Path.Combine(db.PrimaryFilePath, 'MyDataBase_Log.ldf');
    Restore restore = new Restore();
    BackupDeviceItem deviceItem = 
        new BackupDeviceItem('d:\MyDATA.BAK', DeviceType.File);
    restore.Devices.Add(deviceItem);
    restore.Database = backupDatabaseTo;
    restore.FileNumber = restoreFileNumber;
    restore.Action = RestoreActionType.Database;
    restore.ReplaceDatabase = true;
    restore.SqlRestore(smoServer);
    
    db = smoServer.Databases['MyDataBase'];
    db.SetOnline();
    smoServer.Refresh();
    db.Refresh();
