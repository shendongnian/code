        public async Task<CsvFileData> GetCsvFileDataAsync(DataModel model)
        {
            var csvFileData = new CsvFileData();
           
            using (var memoryStream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(memoryStream))
                using (var csvWriter = new CsvWriter(streamWriter))
                {
                    csvWriter.WriteHeader<DataModel>();
                    csvWriter.NextRecord();
                    csvWriter.WriteRecord(model);
                }
                csvFileData.Content = memoryStream.ToArray();
            }
            csvFileData.Name = $"test.csv";
            return csvFileData;
        }
2. In controller
	var csvFileData = GetCsvFileDataAsync(model);
            if (csvFileData == null)
            {
               // log error and return proper status code
            }
            return File(csvFileData.Content, "text/csv", csvFileData.Name);
