    private void BackupIfNecessary()
    {
        var name = "localhost";
        const string path = @"C:\Creation\Name\backupdb\";
        var listfiles = Directory.GetFiles(@"C:\Creation\Name\backupdb\", "backup-*.zip").ToList();
        var files = listfiles.Select(Path.GetFileName).ToList();
        DateTime lastBackup = DateTime.MinValue;
        foreach (var file in files)
        {
            var creationtime = File.GetCreationTime(file);
            // Check if the creation date for this file is the "latest"
            if (creationtime > lastBackup)
            {
                // Store as the "latest" time
                lastBackup = creationtime;
            }
        }
        var diff = DateTime.Now.Subtract(lastBackup);
        if (diff.TotalHours >= 24)
        {
            // The last backup file was created over 24 hours ago; You should create the file
        }
    }
