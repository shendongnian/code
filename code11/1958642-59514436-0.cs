    using (var stream = new MemoryStream(excel_file))
    {
        using (ExcelReaderFactory.CreateReader(stream))
        {
            while (reader.Read())
            {
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var value = reader.GetValue(i)?.ToString();
                }
            }
        }
    }
