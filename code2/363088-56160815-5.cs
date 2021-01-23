           public DataTable GetDataTable(string strSql, List<SqlParameter> parameters)
    		{
    			DataTable dt = new DataTable();
    			try
    			{
    				using (SqlConnection connection = this.GetConnection())
    				{
    					SqlCommand sqlComm = new SqlCommand(strSql, connection);
    
    					if (parameters != null && parameters.Count > 0)
    					{
    						sqlComm.Parameters.AddRange(parameters.ToArray());
    					}
    
    					using (SqlDataAdapter da = new SqlDataAdapter())
    					{
    						da.SelectCommand = sqlComm;
    						da.Fill(dt);
    					}
    					sqlComm.Parameters.Clear(); //this added and error resolved
    				}
    			}
    			catch (Exception ex)
    			{    				
    				throw;
    			}
    			return dt;
    		}
