    StringBuilder sb = new StringBuilder();
    for (int index = 0; index < reader.FieldCount; index++)
    {
        object value = reader[index];
        if (value != DBNull.Value)
            sb.Append(value.ToString());
    }
    result.TextContent = sb.ToString();
