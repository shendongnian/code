    private DataTable GetData(string query)
    {
        // New Connection String
        string connetionString = ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
        // Instantiate the SQL Connection with Connection String
        SqlConnection cnn = new SqlConnection(connetionString);
        // declare datatable
        var dt = new DataTable();    
        // create SqlDataAdapter 
        using (var da = new SqlDataAdapter(query, cnn))
        {      
            // fill datatable
            da.Fill(dt);
        }
      
        return dt;
    }
