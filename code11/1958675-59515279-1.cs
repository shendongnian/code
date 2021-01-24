    public double GetPercentage(string key)
    {
        using (var stream = new FileStream("JobList.csv", FileMode.Open))
        {
            using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
            {
                while (reader.Read()) 
                {
                    var valueColumn1 = reader.GetValue(0)?.ToString();
                    if (key == valueColumn1)
                    {
                        return double.TryParse(reader.GetValue(1)?.ToString(), out var percentage)
                            ? percentage
                            : 0;
                    }
                }
            }
        }
        return 0;
    }
