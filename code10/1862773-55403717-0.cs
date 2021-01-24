csharp
public static IEnumerable<string> GetCSVLines(string[][] list)
{
    using (MemoryStream stream = new MemoryStream())
    using (StreamWriter writer = new StreamWriter(stream))
    using (CsvHelper.CsvWriter csv = new CsvHelper.CsvWriter(writer))
    {
        csv.Configuration.ShouldQuote = (field, context) => true;
        foreach (var item in list)
        {
            foreach (var field in item)
            {
                csv.WriteField(field);
            }
            yield return csv.Record; //??
            csv.NextRecord();                  
        }                 
    }
}
