    using (var con = new SqlConnection("conection string"))
    {
    	con.Open();
    	using (var cmd = con.CreateCommand())
    	{
    		// Here is where we add the parameters into the Sql Query, this way it will prevent SQL Injection
    		cmd.CommandText = "select * from college where class = @class";
    		// Now we add the value to the parameter @class, I'm assuming here that the column class is a NVarchar
            cmd.Parameters.Add("@class", SqlDbType.NVarChar).Value = txtclass.Text;
    		using (var dr = cmd.ExecuteReader())
    		{
    			while (dr.Read())
    			{
    				// Do some code
    			}
    			dr.Close();
    		}
    	}
    }
