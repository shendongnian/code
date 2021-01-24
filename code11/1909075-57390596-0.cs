    public async Task<IActionResult> ConvertExcelToJson()
    {
        var inFilePath = @"xx\Wave.xlsx";
        var outFilePath = @"xx\text.json";
        using (var inFile = System.IO.File.Open(inFilePath, FileMode.Open, FileAccess.Read))
        using (var outFile = System.IO.File.CreateText(outFilePath))
        {
            using (var reader = ExcelReaderFactory.CreateReader(inFile, new ExcelReaderConfiguration()
            { FallbackEncoding = Encoding.GetEncoding(1252) }))
            {
                var ds = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });
                var table = ds.Tables[0];
                var json = JsonConvert.SerializeObject(table, Formatting.Indented);
                outFile.Write(json);
            }
        }
        return Ok();
    }
