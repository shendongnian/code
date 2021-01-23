    Server databaseServer = new Server(new ServerConnection(CvVariables.SQL_SERVER_NAME));
    string databasePath = @"D:\cvdb.bak";
    // Generate new FilePath for both Files.
    string fileMdf = System.IO.Path.Combine(databaseServer.MasterDBPath, "Cafeteria_Vernier_db.mdf");
    string fileLdf = System.IO.Path.Combine(databaseServer.MasterDBLogPath, "Cafeteria_Vernier_db_log.ldf");
    RelocateFile relocateMdf = new RelocateFile("Cafeteria_Vernier_db", fileMdf);
    RelocateFile relocateLdf = new RelocateFile("Cafeteria_Vernier_db_log", fileLdf);
    Restore databaseRestore = new Restore();
    databaseRestore.Action = RestoreActionType.Database;
    databaseRestore.Database = CvVariables.Catalog;
    databaseRestore.Devices.Add(new BackupDeviceItem(databasePath, DeviceType.File));
    databaseRestore.RelocateFiles.Add(relocateMdf);
    databaseRestore.RelocateFiles.Add(relocateLdf);
    databaseRestore.ReplaceDatabase = true;
    databaseRestore.SqlRestore(databaseServer);
