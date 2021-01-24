    private void PopulateDropdowns()
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["name of your connection string"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {               
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "name of your stored procedure";
    
                // Double check that the connection is open                    
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
    
                // Create a SqlDataAdapter and fill it with the data from your stored procedure                     
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
    
                // Since you have so many, I would name the DataSet tables
                // These will correspond with each of your SELECT statements
                // with 0 being the first SELECT, 1 being the second SELECT and so on
                ds.Tables[0].TableName = "Location";
                ds.Tables[1].TableName = "Department";
    
                // Then set their DataSources
                // and bind each table to its corresponding dropdown
                ddlLocation.DataSource = ds.Tables["Location"];
                ddlLocation.DataValueField = "id";
                ddlLocation.DataTextField = "location";
                ddlLocation.DataBind();
    
                ddlDepartment.DataSource = ds.Tables["Department"];
                ddlDepartment.DataValueField = "id";
                ddlDepartment.DataTextField = "department";
                ddlDepartment.DataBind();
            }
        }
    }
