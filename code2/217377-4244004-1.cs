    public int Execute(String block, dbStudio.components.DbsTab host)
    {
    	this.Connect();
    	DbCommand cmd = this.dbConnection.CreateCommand();
    	DbDataReader reader = null;
    
    	cmd.CommandText = block;
    	int ret = -1;
    
    	try
    	{
    		long ticks = DateTime.Now.Ticks;
    		reader = cmd.ExecuteReader();
    		do
    		{
    			while (reader.Read())
    			{
    				String str = "";
    				for (int i = 0; i < reader.FieldCount; i++)
    				{
    					//host.WriteLine("Field " + i + ": " + reader[i].ToString());
    					str = str + reader[i].ToString() + "    ";
    				}
    				host.WriteLine(str);
    			}
    		} while (reader.NextResult());
    
    		host.WriteLine("Block executed successfuly");
    		host.WriteLine(reader.RecordsAffected.ToString() + " Affected rows.");
    		host.WriteLine(((DateTime.Now.Ticks - ticks) / 1000).ToString() + "ms");
    
    		ret = reader.RecordsAffected;
    	}
    	catch (Exception e)
    	{
    		host.WriteLine(e.Message);
    	}
    	finally
    	{
    		this.Disconnect();
    	}
    	return ret;
    }
