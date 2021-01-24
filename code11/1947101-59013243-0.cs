	private void button1_Click(object sender, EventArgs e)
    {
        try
		{
            const connStr = "datasource=xxx;port=111;username=xxx;password=xxx"; // constant
            // Instead of "select *" select particular column(s), it will help with reader columns later
		    var sql = "select column1 from xxx.lojass where nome = @1"; // you need to parameterize. Never push text box value directly into sql
		    // important to use "using" to release resources
		    using (var conn = new MySqlConnection(connStr))
		    {
		        using (var cmd = new MySqlCommand(sql, conn))
		        {
                    // assuming "nome" is string. If the value is other datatype - convert it
                    // Better yet - create parameter where you explicitly specify mySql data type 
				    cmd.Parameters.AddWithValue("@1", textBox1.Text); 
				    conn.Open(); 
				    using (var reader = cmd.ExecuteReader()) // Since single value expected another way doing it - ExecuteScalar
				    {
					    // you only fill one single value, so makes sense to use IF, not WHILE
	    				if (reader.Read()) 
		    				label1.Text = reader["column1"].ToString();
			    	}
	    	    }	
		    }
		}
		catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
