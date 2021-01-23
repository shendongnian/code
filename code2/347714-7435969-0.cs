    public void nonQuery(string txtQuery)
    {
    	using(var conn = new FbConnection(GetMyConnectionString(...parameters...)))
    	{
    		using(var cmd = new FbCommand(txtQuery))
    		{
    			try
    			{			
    				cmd.Connection = conn;
    				conn.Open();
    				
    				cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
    				showDbError(ex.Message);
                    throw;
                }
    		}
    	}
    }
