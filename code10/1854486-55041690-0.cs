    private void check_Click(object sender, EventArgs e)
    {
    	string insertQuery = "INSERT INTO tbl_phones(model) VALUES(@model)";
    	string checkQuery = "SELECT COUNT(*) FROM tbl_phones WHERE model = @model";
    
    	using (SqlConnection sqlconn = new SqlConnection(@""))
    	{
    		sqlconn.Open();
    		
    		SqlCommand checkCommand = new SqlCommand(checkQuery, sqlconn);
    		checkCommand.Parameters.AddWithValue("@model", phoneinput.Text);
    
    		if((int)checkCommand.ExecuteScalar.ExecuteScalar() < 1)
    		{
    			SqlCommand insertCommand = new SqlCommand(insertQuery, sqlconn);
    			insertCommand.Parameters.AddWithValue("@model", phoneinput.Text);
    			insertCommand.ExecuteNonQuery();
    		}
    	}
    }
