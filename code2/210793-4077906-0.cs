    SqlCommand comm;
    if (cbBackup.Checked)
    {
        log("Making backup, this might take a while..");
    
        comm = new SqlCommand(GetFromResources("databaseInstaller.qry.osrose_backup.sql"), conn);
    }
    else
    {
        comm = new SqlCommand(GetFromResources("databaseInstaller.qry.anotherfile.sql"), conn);
    }
