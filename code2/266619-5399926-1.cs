    public DataTable GetByEmailAddress(AdministratorsBO administrator)
    {
    	Using (SqlConnection conn = new SqlConnection(MyGlobals.conString))
    	{
    		SqlCommand dCmd = new SqlCommand("administratorGetByEmailAddress", conn);
    		dCmd.CommandType = CommandType.StoredProcedure;
    		DataSet dSet = new DataSet();
    		
    		dCmd.Parameters.AddWithValue("@emailAddress", administrator.EmailAddress);
    
    		SqlDataAdapter dAd = new SqlDataAdapter(dCmd);
    
    		dAd.Fill(dSet);
    		return dSet.Tables[0];
    	}
    }
