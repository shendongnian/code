    private const string ConnectionString = "...";
    private const string Query = "SELECT Id, Name FROM Users";
    public IEnumerable<User> GetUsers()
    {
        using (var cn = new SqlConnection(ConnectionString))
            return cn.Query<SerieDailyValueDto>(Query).ToArray();
    }
    public Task<IEnumerable<User>> GetUsersAsync()
    {
        using (var cn = new SqlConnection(ConnectionString))
            return await cn.QueryAsync<SerieDailyValueDto>(Query).ToArray();
    }
