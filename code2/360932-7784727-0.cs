    SqlConnection conn = new SqlConnection(ConnectionString);
    SqlCommand com = new SqlCommand ("show databases",conn);
    conn.Open();
    SqlDataReader reader = com.ExecuteReader();
    DataTable dt = new DataTable;
    dt.Load(reader);
    DataRows[] rows = dt.Rows;
