	private void Button1_Click_1(object sender, EventArgs e)
	{
        Server server = new Server(new ServerConnection(".\\sqlexpress", "sa", "underadmin"));
        Backup backup = new Backup() { Action = BackupActionType.Database, Database = "TestMedia" };
        backup.Devices.AddDevice(@"D:\BACKUP\TestMedia.bak", DeviceType.File);
        backup.Initialize = true;
        backup.PercentComplete += Backup_PercentComplete;
        backup.Complete += (o,e) => { this.Close(); };
        backup.SqlBackupAsync(server);
	}
