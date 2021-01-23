    void AddParams(DBCommand cmd,params object[] parameters)
    {
    	if (parameters != null)
    	{
    		int index = 0;
    		while (index < parameters.Length)
    		{
    			cmd.Parameters.AddWithValue("@"+(string)parameters[index], parameters[index + 1]);
    			index += 2;
    		}
    	}
    }
