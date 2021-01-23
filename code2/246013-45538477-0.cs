    using (var location = new SQLiteConnection(@"Data Source=activeDb.db; Version=3;"))
    using (var destination = new SQLiteConnection(@"Data Source=backupDb.db; Version=3;"))
    {
         location.Open();
         destination.Open();
         location.BackupDatabase(destination, "main", "main", -1, null, 0);
    }
