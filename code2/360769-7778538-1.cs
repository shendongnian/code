      static void Read()
      {
        try
        {
          string connectionString =
                "server=.;" +
                "initial catalog=employee;" +
                "user id=sa;" +
                "password=sa123";
            using (SqlConnection conn =new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM EmployeeDetails", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
    
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("Id = ", reader["Id"]);
                            Console.WriteLine("Name = ", reader["Name"]);
                            Console.WriteLine("Address = ", reader["Address"]);
                        }
                    }
    
                    reader.Close();
                }
            }
        }
        catch (SqlException ex)
        {
            //Log exception
            //Display Error message
        }
    }
    
    static void Insert()
    {
        try
        {
            string connectionString =
                "server=.;" +
                "initial catalog=employee;" +
                "user id=sa;" +
                "password=sa123";
            using (SqlConnection conn =new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO EmployeeDetails VALUES(" +
                       "@Id, @Name, @Address)", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", 1);
                    cmd.Parameters.AddWithValue("@Name", "Amal Hashim");
                    cmd.Parameters.AddWithValue("@Address", "Bangalore");
    
                    int rows = cmd.ExecuteNonQuery();
    
                    //rows number of record got inserted
                }
            }
        }
        catch (SqlException ex)
        {
            //Log exception
            //Display Error message
        }
    }
    
    static void Update()
    {
        try
        {
            string connectionString =
                "server=.;" +
                "initial catalog=employee;" +
                "user id=sa;" +
                "password=sa123";
            using (SqlConnection conn = ew SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd =
                new SqlCommand("UPDATE EmployeeDetails SET Name=@NewName, Address=@NewAddress WHERE Id=@Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", 1);
                    cmd.Parameters.AddWithValue("@Name", "Munna Hussain");
                    cmd.Parameters.AddWithValue("@Address", "Kerala");
    
                    int rows = cmd.ExecuteNonQuery();
    
                    //rows number of record got updated
                }
            }
        }
        catch (SqlException ex)
        {
            //Log exception
            //Display Error message
        }
    }
    
    static void Delete()
    {
        try
        {
            string connectionString =
                "server=.;" +
                "initial catalog=employee;" +
                "user id=sa;" +
                "password=sa123";
            using (SqlConnection conn = ew SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("DELETE FROM EmployeeDetails " +
                        "WHERE Id=@Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", 1);
                    
                    int rows = cmd.ExecuteNonQuery();
    
                    //rows number of record got deleted
                }
            }
        }
        catch (SqlException ex)
        {
            //Log exception
            //Display Error message
        }
    }
