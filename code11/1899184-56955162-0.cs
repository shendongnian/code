csharp
public static async Task GenerateCsv<T>(Stream stream, IEnumerable<T> data)
{
    using (var sw = new StreamWriter(stream, Encoding.UTF8))
    using (var writer = new CsvWriter(sw))
    {
        foreach (var record in data)
        {
            writer.WriteRecord(record);
            await writer.NextRecordAsync();
        }
    }
}
