    while (reader.Read()) 
    {
        for (int i = 0; i < reader.FieldCount; i++)
        {
            Response.Write(reader.GetString(i));
        }
    }
