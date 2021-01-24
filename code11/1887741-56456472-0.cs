    private void Button1_Click_1(object sender, EventArgs e)
        {
            ShowLoading(() =>
            {
                Server server = new Server(new ServerConnection(".\\sqlexpress", "sa", "underadmin"));
                Backup backup = new Backup() { Action = BackupActionType.Database, Database = "TestMedia" };
                backup.Devices.AddDevice(@"D:\BACKUP\TestMedia.bak", DeviceType.File);
                backup.Initialize = true;
                backup.PercentComplete += (s, ev) => lblPercent.Text = ev.Percent.ToString();
                backup.SqlBackup(server);
                return 0;
            });
        }
        private void ShowLoading<T>(Func<T> func)
        {
            var bgk = new BackgroundWorker();
            bgk.DoWork += (s, e) => func.Invoke();
            bgk.RunWorkerCompleted += (s, e) => this.Close();
            bgk.RunWorkerAsync();
        }
