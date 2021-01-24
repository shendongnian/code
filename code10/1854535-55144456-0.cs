    private static OracleConnection GetConnection()
    {
        return new OracleConnection(new OracleConnectionStringBuilder
        {
            //TODO: Set other connection string properties
            ConnectionTimeout = 0
        }.ConnectionString);
    }
