    protected virtual async Task<bool?> IsProcedureDeployed(string storedProcedureName)
    {
    	bool IsDeployed = false;
    	using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString))
    	{
    		conn.Open();
    		using (var cmd = new SqlCommand("select count(*) from sysobjects where type = 'P' and name = @storedProcedureName", conn))
    		{
    			cmd.Parameters.Add("@storedProcedureName", SqlDbType.NVarChar, 128).Value = storedProcedureName; //using nvarchar(128) because object names use sysname which is a synonym for nvarchar(128)
    			var result = await cmd.ExecuteScalarAsync();
    			bool.TryParse(result.ToString(), out IsDeployed);
    		}
    	}
    	return IsDeployed;
    }
    
