    Server srvSql;
    //Connect to Server using your authentication method and load the databases in srvSql
    // THEN
    Backup bkpDatabase = new Backup();
    bkpDatabase.Action = BackupActionType.Database;
    bkpDatabase.Incremental = true; // will take an incemental backup
    bkpDatabase.Incremental = false; // will take a Full backup 
    bkpDatabase.Database = "your DB name";
    BackupDeviceItem bDevice = new BackupDeviceItem("Backup.bak", DeviceType.File);
    bkpDatabase.Devices.Add(bDevice );
    
    bkpDatabase.PercentCompleteNotification = 1;// this for progress
    bkpDatabase.SqlBackup(srvSql);
    bkpDatabase.Devices.Clear();
