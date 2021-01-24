    public static async Task<IEnumerable<Students>> GetStudentsListAsync()
    {
        var db = new SQLiteAsyncConnection("Data Source=assets\\mydb.db;New=False;Version=3");
        return await db.QueryAsync<Students>("select * from students");
    }
