        DataTable data = new DataTable();
        using (SQLiteConnection conn = new SQLiteConnection("Data Source=local.db;Version=3;New=False;Compress=True;"))
        using (SQLiteCommand mycommand = new SQLiteCommand(conn))
        {
            mycommand.CommandText = "SELECT * FROM TAGTABLE WHERE TAG = @tag;";
            mycommand.Parameters.AddWithValue("@tag", tag);
            conn.Open();
            using (SQLiteDataReader reader = mycommand.ExecuteReader())
            {
                data.Load(reader);  
            }
        }
        return data;
