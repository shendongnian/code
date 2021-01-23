        private MySqlConnection NewConnection(string host, int port, string database, string user, string password)
        {
            if (port <= 0) port = 3306;
            string cstr = "";
            if (database == "")
                cstr = String.Format("SERVER={0};PORT={1};UID={2};PWD={3}",
                    host, port, user, password);
            else
                cstr = String.Format("SERVER={0};PORT={1};DATABASE={2};UID={3};PWD={4}",
                    host, port, database, user, password);
            MySqlConnection conn = new MySqlConnection(cstr);
            try { conn.Open(); }
            catch (Exception ex)
            {
                conn = null;
            }
            return conn;
        }
        public int ExecuteScript(MySqlConnection conn, string sql)
        {
            err = "";
            int totrows = -1;
            if (conn == null) return totrows;
            if (conn.State == System.Data.ConnectionState.Closed) conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            try
            {
                totrows = cmd.ExecuteNonQuery();
                cmd = null;
                return totrows;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return 0;
            }
        }
    public bool Restore(string dbHost, int dbPort, string dbUser, string dbPassword, string file)
    {
    	int toterr = 0;
    	int totsql = 0;
    	string msql = "";
    	StreamReader rd = null;
    	FileStream fs = null;       
        
    	MySqlConnection conn = NewConnection(dbHost, dbPort, "", dbUser, dbPassword);
    	if (conn == null) return false;
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
    				rows = ExecuteScript(conn, s);
    			}
    			catch
    			{
    				toterr++;
                    break;
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
