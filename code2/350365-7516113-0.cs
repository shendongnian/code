    SQLiteConnectionStringBuilder builder = new SQLiteConnectionStringBuilder();
    builder.FailIfMissing = true;
    builder.DataSource = "Insert the fully qualified path to your sqlite db";
    SQLiteConnection connection = new SQLiteConnection(builder.ConnectionString);
    connection.Open();
