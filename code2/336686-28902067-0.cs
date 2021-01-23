    using (SqlCommand command = new SqlCommand("SELECT * FROM vwGetData", conn))
    {
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
                Console.Writeline(reader.GetName(i));
        }
    }
