    private void BindData()
    {
        // Wrap the whole thing in a using() because it automatically closes the connection
        // when it's done so you don't have to worry about doing that manually
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["name of your connection string"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                // Set the releveant properties like you already had                
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PP_spSearchReturnCrate";
                    
                // Double check that the connection is open                    
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                    
                // Create your SqlDataAdapter and fill it with your data                     
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                    
                // Then set that as the DataSource, and finally bind it to your drop down
                ddlDriver.DataSource = ds.Tables[0];
                ddlDriver.DataBind();
            }
        }
    }
