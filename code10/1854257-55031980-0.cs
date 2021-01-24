    var parameters = new DynamicParameters();
    parameters.Add("@MyParameter", value);
    parameters.Add("@MySecondParameter", value2);
    using (IDbConnection connection = new SqlConnection(_databaseConnectionString.ConnectionString))
    {
        db.ExecuteAsync("dbo.BoardgameCollectionClear", parameters, commandType: CommandType.StoredProcedure);
    }
