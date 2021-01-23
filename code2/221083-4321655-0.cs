    using(var sConnection = new
        SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
    {
        //To Open the connection.
        sConnection.Open();
        string selectDatabase = @"
            SELECT    [NAME]
            FROM    [master]..[sysdatabases]";
        //Instance of command is created.
        using(var sCommand = new SqlCommand(selectDatabase, sConnection)) {
             // etc
        }
    }
