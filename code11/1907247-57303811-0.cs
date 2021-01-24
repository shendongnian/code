    var connectionStringBuilder = new MySqlConnectionStringBuilder
    {
        Server = "<Instance_Ip>",
        UserID = "root",
        Password = "<Password>",
        Database = "<Database_Name>"
    };
    using (var conn = new MySqlConnection(connectionStringBuilder.ToString()))
