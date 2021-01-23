    public static SqlDataAdapter GetDataAdapter(SqlConnection connection, string Query)
    {
        SqlDataAdapter Adapt = new SqlDataAdapter(Query);
        Adapt.Connection = connection;
        return Adapt;
    }
