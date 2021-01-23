	public DataTable GetData(SqlCommand cmd)
	{
		DataTable dt = new DataTable();
		string strConnString  = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
		using (SqlConnection con = new SqlConnection(strConnString))
		{
			cmd.Connection = con;
			using (SqlDataAdapter sda = new SqlDataAdapter())
			{
				cmd.CommandType = CommandType.Text;
				con.Open();
				sda.SelectCommand = cmd;
				sda.Fill(dt);
			}
		}
		return dt;
	}
	
