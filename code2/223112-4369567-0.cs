    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
    // set properties on  builder (omitted for brevity)
    
    using (SqlConnection connection = new SqlConnection(builder.ToString()))
    using (SqlCommand command = connection.CreateCommand())
    {
        command.CommandType = System.Data.CommandType.Text;
        command.CommandText = "SELECT * FROM Employee WHERE WhenHire < @HireDate";
        // make sure to have a SqlDbType.DateTime parameter!
        SqlParameter hireDateParameter = new SqlParameter("@HireDate", SqlDbType.DateTime);
        hireDateParameter.Value = DateTime.Now;
        command.Parameters.Add(hireDateParameter);
        // don't open the connection too early - this is early enough here!
        connection.Open();
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
               // do stuff
            }
        }
    }
