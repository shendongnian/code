    DataTable dt = new DataTable();
    string connString = ...;
    string sqlCommand = ...;
    using (SqlConnection connection = new SqlConnection(connString))
    using (SqlCommand command = new SqlCommand(sqlComman, connection))
    {
        connection.Open();
        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
        {
            adapter.Fill(dt);
        }
    }    
    
    gd.DataSource = dt;
    gd.DataBind();
