csharp
public static void Main(string[] args)
{
    using (var reader = new StreamReader("path\\to\\file.csv"))
    using (CsvReader csv = new CsvReader(reader))
    {
        csv.Read();
        csv.ReadHeader();
        if (!csv.Context.HeaderRecord.Contains("myHeaderColumnName"))
        {
            csv.Configuration.HasHeaderRecord = false;
            reader.BaseStream.Position = 0;
        }
        var records = csv.GetRecords<MyModel>().ToList();                        
    }
}
