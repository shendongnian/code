    using (SqlConnection conn = new SqlConnection("Connection String"))
    using (SqlCommand comm = new SqlCommand("INSERT INTO MyTable (Name, Age) VALUES (@name, @age)", conn))
    {    
        conn.Open();
        comm.Parameters.AddWithValue("@name", "Adam");
        comm.Parameters.AddWithValue("@age", 25);
  
        comm.ExecuteNonQuery();
    }
