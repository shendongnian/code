    string dbPath = Path.Combine (
            Environment.GetFolderPath (Environment.SpecialFolder.Personal),
            "items.db3");
    bool exists = File.Exists (dbPath);
    if (!exists)
        SqliteConnection.CreateFile (dbPath);
    var connection = new SqliteConnection ("Data Source=" + dbPath);
    connection.Open ();
    if (!exists) {
        // This is the first time the app has run and/or that we need the DB.
        // Copy a "template" DB from your assets, or programmatically create one.
        var commands = new[]{
            "CREATE TABLE [Items] (Key ntext, Value ntext);",
            "INSERT INTO [Items] ([Key], [Value]) VALUES ('sample', 'text')"
        };
        foreach (var command in commands) {
            using (var c = connection.CreateCommand ()) {
                c.CommandText = command;
                c.ExecuteNonQuery ();
            }
        }
    }
    // use `connection`...
    // here, we'll just append the contents to a TextView
    using (var contents = connection.CreateCommand ()) {
        contents.CommandText = "SELECT [Key], [Value] from [Items]";
        var r = contents.ExecuteReader ();
        while (r.Read ())
            MyTextView.Text += string.Format ("\n\tKey={0}; Value={1}",
                    r ["Key"].ToString (), r ["Value"].ToString ());
    }
    connection.Close ();
