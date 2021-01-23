    public string ReadKey(Expression<Func<Keys, string>> selector)
    {
        DataContext dc = new DataContext(sqlconn);
        Table<Keys> keysTable = dc.GetTable<Keys>();
    
        // Generally speaking you don't want to use AsEnumerable here...
        var query = keysTable.Select(selector);
        // Now do something with query
    }
