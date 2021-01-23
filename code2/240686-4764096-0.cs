      Server server = new Server(new Microsoft.SqlServer.Management.Common.ServerConnection(sqlConnection));
      // Create a backup device
      Backup backup = new Backup();
      backup.Action = BackupActionType.Database;
      backup.Database = database;
      backup.Incremental = false;
      backup.Initialize = true;
      BackupDeviceItem backupDeviceItem = new BackupDeviceItem(backupPath, DeviceType.File);
      backup.Devices.Add(backupDeviceItem);
      backup.PercentCompleteNotification = 1;
      backup.Information += new Microsoft.SqlServer.Management.Common.ServerMessageEventHandler(backup_Information);
      backup.PercentComplete += new PercentCompleteEventHandler(backup_PercentComplete);
      backup.Complete += new Microsoft.SqlServer.Management.Common.ServerMessageEventHandler(backup_Complete);
      backup.SqlBackupAsync(server);
