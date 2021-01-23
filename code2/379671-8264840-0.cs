    	private void UpdateOrAddNewRecord(string parametervalue1, string parametervalue2)
	        {
        	    using (openconn())
	            {
	                string sqlStatement = string.Empty;
	                sqlStatement = "Update TableName set Name1 =@Name1 where Name2@Name2";
	
	
	                try
	                {
	                //  SqlCommand cmd = new SqlCommand("storedprocedureName", con);
	                  //cmd.CommandType = CommandType.StoredProcedure;
	
	                    SqlCommand cmd = new SqlCommand(sqlStatement, con);
	                    cmd.Parameters.AddWithValue("Name2", parametervalue2);
	                    cmd.Parameters.AddWithValue("@Name1",parametervalue1);
	                   
        	            cmd.CommandType = CommandType.Text;
                	    cmd.ExecuteNonQuery();
	                }
	                catch (System.Data.SqlClient.SqlException ex)
        	        {
	                    string msg = "Insert/Update Error:";
	
        	            msg += ex.Message;
	
        	            throw new Exception(msg);
        	        }
	
        	        finally
                	{
	                    closeconn();
	
        	        }
        	    }	
