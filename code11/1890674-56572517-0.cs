     static void UpdateDatabase(int primaryKey, string newText, int newValue)
    {
        string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "mydatabase.db");
        var db = new SQLiteConnection(path, false);
        string sql = "UPDATE MyTable SET MyTextColumn = ?, MyValueColumn = ? WHERE MyPrimaryKey= ?";
        string[] parms = new String[] { newText, newValue.ToString(), primaryKey.ToString() };
        var cmd = db.CreateCommand(sql, parms);
        cmd.ExecuteNonQuery();
    }
