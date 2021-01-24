	public DataSet ExecuteQuery2(string storedProcedureName, List<SqlParameter> param)
	{
		DataSet ds = new DataSet();
		using (SqlConnection cn = GetConnection(""))
		{
			using (SqlCommand cmd = cn.CreateCommand())
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = storedProcedureName;
				cmd.Parameters.AddRange(param.ToArray());                    
				using (SqlDataAdapter da = new SqlDataAdapter(cmd))
				{
					da.Fill(ds);
				}
			}
		}
		return ds;
	}
