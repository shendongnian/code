csharp
using (var reader = new StreamReader(filePath, Encoding.Default))
{
    using (var csv = new CsvReader(reader))
    {
        csv.Configuration.Delimiter = ";";
        csv.Configuration.IgnoreQuotes = true;
        csv.Read();
        csv.ReadHeader();
        List<string> badRecord = new List<string>();
        csv.Configuration.BadDataFound = context => badRecord.Add(context.RawRecord);
        header = csv.Context.HeaderRecord.ToList();
        while (true)
        {
            var dataRow = csv.Parser.Read();
            if (dataRow == null)
            {
                break;
            }
            data.Add(dataRow);
        }
    }
}
