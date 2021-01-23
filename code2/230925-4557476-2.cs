    public static System.Data.DataTable SQLServerPull()
        {
    		System.Data.DataTable dt = new System.Data.DataTable();
            string server = "p";
            string database = "IBpiopalog";
            string security = "SSPI";
            string sql = "select server from dbo.ServerList";
            using(SqlConnection con = new SqlConnection("Data Source=" + server + ";Initial Catalog=" + database + ";Integrated Security=" + security))
    		{
    			con.Open();
    			using(SqlCommand cmd = new SqlCommand(sql, con))
    			{
    				using(SqlDataReader dr = cmd.ExecuteReader())
    				{
    					dt.Load(dr);
    				}
    			}
    		}
    		return dt;
        }
