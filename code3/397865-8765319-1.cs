    public static SqlDataAdapter GetDataAdapter(string Query, SqlConnetion conn)
    {
        SqlDataAdapter Adapt = new SqlDataAdapter(Query, conn);
        return Adapt;
    }
