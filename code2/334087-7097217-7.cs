    using (var con = new SqlConnection(connstring))
    {
    	con.Open();
    	
    	using (SqlCommand cmd = new SqlCommand("exec sp_UseStringList @list", con))
        {
    		var table = new DataTable();
    		table.Columns.Add("Item", typeof(string));
    		
    		for (int i = 0; i < 10; i++)
    			table.Rows.Add("Item " + i.ToString());
    		
    		var pList = new SqlParameter("@list", SqlDbType.Structured);
    		pList.TypeName = "dbo.StringList";
    		pList.Value = table;
            cmd.Parameters.Add(pList);
    		
    		using (var dr = cmd.ExecuteReader())
    		{
    			while (dr.Read())
    				Console.WriteLine(dr["Item"].ToString());
    		}
        }
    }
                     
