    public static Task<IEnumerable<Students>> GetStudentsListAsync()
    {
        var db = new SQLiteAsyncConnection("Data Source=assets\\mydb.db;New=False;Version=3");
        return db.QueryAsync<Students>("select * from students");
    }
