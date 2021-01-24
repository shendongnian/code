csharp
using (var writer = new System.IO.StreamWriter(journalsCsvSFD.OpenFile()))
using (var csv = new CsvHelper.CsvWriter(writer))
{
    csv.Configuration.TypeConverterOptionsCache.GetOptions<DateTime>().Formats = new[] { "dd/MM/yyyy" };
    csv.WriteRecords(records);
}
