    using(SqlConnection con = new SqlConnection(".......")) 
    {
        ServerConnection svrConnection = new ServerConnection(con);
        Server server = new Server(svrConnection);
        Backup bk = new Backup();
        bk.PercentComplete += pctComplete;
        bk.Action = BackupActionType.Database;
        bk.Database = con.Database
        bk.Devices.Add(new BackupDeviceItem(svdlg.FileName, DeviceType.File));
        bk.SqlBackup(server);
   }
    void pctComplete(object server, PercentCompleteEventArgs e)
    {
        Console.WriteLine(e.Percent);
    }
