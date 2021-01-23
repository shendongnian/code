		using (SqlConnection con = new SqlConnection("Data Source=;Initial Catalog= ;Integrated Security= SSPI"))
		{
			con.Open();
			using (DataSet ds = new DataSet())
			{
				using (SqlDataAdapter adapter = new SqlDataAdapter(sql, con))
				{
					adapter.Fill(ds);
				}    
			}
		}
