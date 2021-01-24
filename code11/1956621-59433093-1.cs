    using (var conn = new SQLiteConnection(Constants.DatabasePath))
    {
        conn.CreateTable<DBItem>();
        var item = new DBItem();
        item.TextData = addEntry.Text;
        conn.Insert(item);
    }
    
