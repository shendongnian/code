    using (var stream = File.Open("C:\\temp\\input.xlsx", FileMode.Open, FileAccess.Read))
    {
        using (var reader = ExcelReaderFactory.CreateReader(stream))
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
