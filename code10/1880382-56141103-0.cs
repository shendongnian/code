    List<Usuarios> list = new List<Usuarios>();
    using (SqlConnection conConexao1 = clsdb.AbreBanco())
    {
    	using (SqlCommand cmd1 = new SqlCommand(
    		"select id, tamplete1, tamplete2 from usuarios ", conConexao1))
    	{
    		using (SqlDataReader dr1 = cmd1.ExecuteReader())
    		{
    			while (dr1.Read())
    			{
    				list.Add(new Usuarios
    				{
    					Id = dr1.GetInt32(0),
    					Templete1 = dr1[1].ToString(),
    					Templete2 = dr1[2].ToString()
    				});
    			}
    		}
    	}
    }
