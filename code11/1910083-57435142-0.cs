using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
{
    // Auto-detect format, supports:
    //  - Binary Excel files (2.0-2003 format; *.xls)
    //  - OpenXml Excel files (2007 format; *.xlsx)
    using (var reader = ExcelReaderFactory.CreateReader(stream))
    {
        // Choose one of either 1 or 2:
        // 1. Use the reader methods
        do
        {
            while (reader.Read())
            {
                // reader.GetDouble(0);
            }
        } while (reader.NextResult());
        // 2. Use the AsDataSet extension method
        var result = reader.AsDataSet();
        // The result of each spreadsheet is in result.Tables
    }
}
-Example from:
https://github.com/ExcelDataReader/ExcelDataReader 
  [1]: https://www.nuget.org/packages/ExcelDataReader/
