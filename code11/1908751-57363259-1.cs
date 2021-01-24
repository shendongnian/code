	public DataTable ExecuteQuery2(string StoreProce, List<SqlParameter> param)
	{
		DataSet ds = new DataSet();
		using (SqlConnection cn = GetConnection(""))
		{
			using (SqlCommand cmd = cn.CreateCommand())
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = StoreProce;
				cmd.Parameters.AddRange(param.ToArray());                    
				using (SqlDataAdapter da = new SqlDataAdapter(cmd))
				{
					da.Fill(ds);
				}
			}
		}
		
		return ds.Tables[0];   //// here instead of 0 you may pass the table number you want to return
	}
