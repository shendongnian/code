    const string sql = "SELECT TOP 10 * FROM [dbo].[OutboundMessages] ORDER BY [Length] DESC";
    using (SqlConnection connection = new SqlConnection(ConnectionString))
    {
    	connection.Open();
    	using (SqlCommand command = new SqlCommand(sql, connection))
    	using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess))
    	{
    		if (reader.HasRows)
    		{
    			while (reader.Read())
    			{
    				string file = Guid.NewGuid().ToString().Replace("-", string.Empty);
    				using (StreamWriter writer = new StreamWriter(file))
    				{
    					int ordinal = reader.GetOrdinal("FileData");
    					long bytesRead, offset = 0;
    					byte[] buffer = new byte[3072];
    					while ((bytesRead = reader.GetBytes(ordinal, offset, buffer, 0, buffer.Length)) > 0)
    					{
    						offset += bytesRead;
    						writer.Write(Convert.ToBase64String(buffer));
    					}
    				}
    			}
    		}
    	}
    }
