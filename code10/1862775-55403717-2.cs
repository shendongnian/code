csharp
public static IEnumerable<string> GetCSVLines(string[][] list)
{
    using (MemoryStream stream = new MemoryStream())
    using (StreamWriter writer = new StreamWriter(stream))
    using (CsvHelper.CsvWriter csv = new CsvHelper.CsvWriter(writer))
    using (StreamReader reader = new StreamReader(stream))
    {
        csv.Configuration.ShouldQuote = (field, context) => true;
        csv.Configuration.Delimiter = ";";
                
        foreach (var items in list)
        {
            foreach (var item in items)
            {
                csv.WriteField(item);
            }        
            csv.NextRecord();
        }
        writer.Flush();
        stream.Position = 0;
        var records = reader.ReadToEnd().Split('\n').ToList();
        records.RemoveAt(records.Count - 1);
        return records;
    }
}
