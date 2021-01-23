    using Microsoft.SqlServer.Management.Smo;
    
    string backupFile="Backupfile";//.bak file
    
    string dbName = "DBName";
    
    string dbServerMachineName = "MachineName";
    
    Microsoft.SqlServer.Management.Smo.Server server = new Microsoft.SqlServer.Management.Smo.Server(dbServerMachineName);
    
    Database database = new Database(server, dbName);
    
    //If Need
    
    database.Create();
    
    database.Refresh();
    
    //Restoring
    
    Restore restore = new Restore();
    
    restore.NoRecovery = false;
    
    restore.Action = RestoreActionType.Database;
    
    BackupDeviceItem bdi = default(BackupDeviceItem);
    
    bdi = new BackupDeviceItem(backupFile, DeviceType.File);
    
    restore.Devices.Add(bdi);
    
    restore.Database = dbName;
    
    restore.ReplaceDatabase = true;
    
    restore.PercentCompleteNotification = 10;
    
    restore.SqlRestore(server);
    
    database.Refresh();
    
    database.SetOnline();
    
    server.Refresh();
