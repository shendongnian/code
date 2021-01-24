    string insertQuery = @"INSERT INTO dbo.Table1 (FirstName, LastName, City)
    			     	   VALUES (@FirstName, @LastName, @City);";
    				 
    using (SqlCommand cmd = new SqlCommmand(insertQuery, con))
    {
        cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = firstname.Text;
    	cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = lastname.Text;
    	cmd.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = city.Text;
    	
    	con.Open();
    	cmd.ExecuteNonQuery();
    	con.Close()
    }
