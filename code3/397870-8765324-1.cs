    static void Main(string[] args)
    { 
        using (SqlConnection connection = GetConnection()) 
        {
            using (SqlDataAdapter adapter = GetDataAdapter("YourQuery", connection)) 
            {
            }
            // SqlDataAdapter is disposed
        }
        // SqlConnection is disposed
    }
    private static readonly string ConnectionString = "Dummy";
    public static SqlConnection GetConnection()
    {
        SqlConnection Connection = new SqlConnection(ConnectionString);
        return Connection;
    }
    public static SqlDataAdapter GetDataAdapter(string Query, SqlConnection connection)
    {
        SqlDataAdapter Adapt = new SqlDataAdapter(Query, connection);
        return Adapt;
    }
