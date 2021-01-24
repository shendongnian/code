    public IEnumerable<T> ImportStandardCsv<T>(string fileData)
    {
        List<T> data;
        using (var memoryStream = new MemoryStream(Convert.FromBase64String(fileData.Substring(fileData.IndexOf(',') + 1))))
        {
            using (var streamWriter = new StreamReader(memoryStream))
            using (var csvReader = new CsvReader(streamWriter))
            {
                var records = csvReader.GetRecords<T>();
                data = records.ToList();
            }
        }
        return data;
    }
