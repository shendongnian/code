using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
{
    using (var reader = ExcelReaderFactory.CreateReader(stream))
    {
        var result = reader.AsDataSet();
        var table1=result.Tables["Sheet1"];
        foreach(DataRow in table1.Rows)
        {
           //Do something with the row
        }
    }
}    
