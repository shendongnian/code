    while (reader.Read())
    {
        string header = string.Empty;
        for (int i = 0; i < reader.FieldCount; i++)
        {
            header += $", {reader.GetName(i)}";
        }
    }
