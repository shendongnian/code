    using(OleDbConnection db = new OleDbConnection())
    {
    	db.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + fileName; 
    	db.Open(); 
    	
    	string groupName = groupName.Text.Trim();	
    	string sql = "SELECT * FROM GroupNameNS WHERE GroupName = '@groupname'"; 
    	
    	using(OleDbCommand cmd = new OleDbCommand(sql, db))
    	{
    		cmd.Parameters.AddWithValue("@groupname", groupName);
    		
    		using(OleDbDataReader rdr = cmd.ExecuteReader())
    		{		
    			if (rdr.Read()) 
    			{ 
    				MessageBox.Show("Group Name taken, please try another name", "Error in Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
    				membernumber1.ReadOnly = true; 
    			} 
    			else 
    			{ 
    				sql = "INSERT INTO GroupNameNS VALUES ('@groupname')"; 
    				cmd.CommandText = sql;				
    				cmd.ExecuteNonQuery();
    				membernumber1.ReadOnly = false; 		
    			} 
    		}
    	}
    }
