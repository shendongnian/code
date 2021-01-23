    public static SqlConnectionStringBuilder GetConnection()
    {
        SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
        sqlBuilder.DataSource = @"some string";
        sqlBuilder.Password = @"mypassword";
        sqlBuilder.UserID = @"myuserid";
        //set other properties here.
        return sqlBuilder;
    }
