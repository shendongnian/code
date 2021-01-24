    public IEnumerable<T> ImportStandardCsv<T>(string fileData)
    {
        var bytes = Convert.FromBase64String(fileData.Substring(fileData.IndexOf(',') + 1));
        using (var memoryStream = new MemoryStream(bytes))
        using (var streamReader = new StreamReader(memoryStream))
        using (var csvReader = new CsvReader(streamReader))
            return csvReader.GetRecords<T>();
    }
