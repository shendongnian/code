    public bool Restore(string dbHost, int dbPort, string dbUser, string dbPassword, string file)
    {
    	int toterr = 0;
    	int totsql = 0;
    	string msql = "";
    	StreamReader rd = null;
    	FileStream fs = null;
    
    	fs = new FileStream(file, FileMode.Open);
    	rd = new StreamReader(fs);
    	while (rd.Peek() > 0)
    	{
    		string t = rd.ReadLine().Trim();
    		if ((t == "") || (t.StartsWith("--"))) continue;
    		msql += t;
    		if (msql == ";") msql = "";
    		if (msql.EndsWith(";"))
    		{
    			totsql++;
    			msql = "";
    			GC.Collect();
    		}
    	}
    	rd.Close();
    	rd = null;
    	fs.Close();
    	fs = null;
    	GC.Collect();
    
    	MySqlConnection conn = NewConnection(dbHost, dbPort, "", dbUser, dbPassword);
    	if (conn == null) return false;
    	// Eseguo lo script
    	int cur = 0;
    	int rows = 0;
    
    	fs = new FileStream(file, FileMode.Open);
    	rd = new StreamReader(fs);
    	while (rd.Peek() > 0)
    	{
    		string t = rd.ReadLine().Trim();
    		if ((t == "") || (t.StartsWith("--"))) continue;
    		msql += t;
    		if (msql == ";") msql = "";
    		if (msql.EndsWith(";"))
    		{
    			string s = msql.Remove(msql.Length - 1, 1).Trim();
    			msql = "";
    			try
    			{
    				if (SqlBeforeCommand != null) SqlBeforeCommand(s);
    				rows = ExecuteScript(conn, s);
    				if (SqlAfterCommand != null) SqlAfterCommand(s, rows, cur + 1, totsql);
    			}
    			catch
    			{
    				toterr++;
    				bool stop = false;
    				if (SqlCommandError != null) SqlCommandError(s, ref stop);
    				if (stop) break;
    			}
    			finally
    			{
    				cur++;
    			}
    		}
    	}
    	rd.Close();
    	rd = null;
    	fs.Close();
    	fs = null;
    	
    	conn.Close();
    	conn = null;
    	return true;
    }
