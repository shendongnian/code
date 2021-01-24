csharp
private void ExportAsCSV()
{
    using (var memoryStream = new MemoryStream())
    {
        using (var writer = new StreamWriter(memoryStream))
        {
            using (var csv = new CsvHelper.CsvWriter(writer, System.Globalization.CultureInfo.CurrentCulture)
            {
                csv.WriteRecords(people);
            }
            var arr = memoryStream.ToArray();
            js.SaveAs("people.csv",arr);
        }
    }
}
