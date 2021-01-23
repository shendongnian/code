    public IList<your object> PopulateYourObject()
    {
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(your connection string);
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = command;
        if (parameters != null)
        {
            // add any parameters here
        }
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adp = null;
        
        con.Open();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        			
        DataTable dt = ds.Tables[0]; // Now you have a DataTable
    
        return PopulateYourObjectListFromData(dt);
    }
