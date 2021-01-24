	private async Task ShowLoading(Func<Task<int>> func)
	{
		await func.Invoke();
		this.Close();
	}
	private async void Button1_Click_1(object sender, EventArgs e)
	{
		await ShowLoading( async () =>
		{
            Server server = new Server(new ServerConnection(".\\sqlexpress", "sa", "underadmin"));
            Backup backup = new Backup() { Action = BackupActionType.Database, Database = "TestMedia" };
            backup.Devices.AddDevice(@"D:\BACKUP\TestMedia.bak", DeviceType.File);
            backup.Initialize = true;
            backup.PercentComplete += Backup_PercentComplete;
            await backup.SqlBackupAsync(server);
			return 0;
		});
	}
