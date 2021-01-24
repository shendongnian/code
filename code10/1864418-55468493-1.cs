    string connString = @"your connection string here";
    string query = "select * from table";
    DataTable dataTable = new DataTable();
    SqlConnection conn = new SqlConnection(connString);        
    SqlCommand cmd = new SqlCommand(query, conn);
    conn.Open();
    // create data adapter
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    // this will query your database and return the result to your datatable
    da.Fill(dataTable);
    conn.Close();
    da.Dispose();
