    string queryString = "select top 1 column_1, column_2 from master_table";
    using (SqlConnection dbConnection = new SqlConnection(envDBConnectionString))
    {
         SqlCommand dbCommand = new SqlCommand(queryString, dbConnection);
         SqlDataAdapter sa = new SqlDataAdapter(dbCommand);
         DataTable dt = new DataTable(); //All your data in this datatable
         sa.fill(dt);
    }
