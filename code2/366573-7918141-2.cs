    using (SqlConnection connection = new SqlConnection("your connection string"))
    {
        SqlCommand command = new SqlCommand(
          "exec spGetProductsByGroup @ProductID",
          connection);
        command.Parameters.Add(product_id);
          
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        List<ProcType> list = new List<ProcType>();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                list.Add(new ProcType(){Property1 = reader.GetInt32(0), Property1 = reader.GetString(1));
            }
        }
        reader.Close();
        
        return list;
    }
