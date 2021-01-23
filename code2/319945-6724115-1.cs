    SqlConnection dataConnection;
    if (string.IsNullOrEmpty(ConnectionString))
    {
        dataConnection = new SqlConnection(ConnectionString);
    }
    else
    {
        dataConnection = new SqlConnection();
    }
