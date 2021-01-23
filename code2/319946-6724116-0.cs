    SqlConnection conn;
    if(string.IsNullOrEmpty(connectionString)) {
        conn = new SqlConnection();
    } else {
        conn = new SqlConnection(connectionString);
    }
