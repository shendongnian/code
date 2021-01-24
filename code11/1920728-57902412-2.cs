    public bool Insert (rubricaClass c) 
    {
        bool isSuccess = false;
    
        SqlConnection conn = new SqlConnection(myconnstrng);
    	
    	string sql = "INSERT INTO tbl_Rubrica (Nome, Cognome, Telefono1, Telefono, Email) VALUES (@Nome, @Cognome, @Telefono1, @Telefono, @Email)";
    	using(SqlCommand cmd = new SqlCommand(sql, conn))
    	{
    		cmd.Parameters.AddWithValue("@Nome", c.Nome);
    		cmd.Parameters.AddWithValue("@Cognome", c.Cognome);
    		cmd.Parameters.AddWithValue("@Telefono1", c.Telefono1);
    		cmd.Parameters.AddWithValue("@Telefono", c.Telefono);
    		cmd.Parameters.AddWithValue("@Email", c.Email);
    
    		conn.Open();
    		int rows = cmd.ExecuteNonQuery();
    
    		if (rows > 0)
    		{
    			isSuccess = true;  
    		}
    		else
    		{
    			isSuccess = false;
    		}
    	}
    	
        return isSuccess;
    }
