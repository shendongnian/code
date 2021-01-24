    using (var stream = new FileStream("JobList.csv", FileMode.Open))
    {
        using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
        {
            while (reader.Read())    //this will read row by row
            {
                var valueColumn1 = reader.GetValue(0)?.ToString();
                var valueColumn2 = reader.GetValue(1)?.ToString();
            }
        }
    }
