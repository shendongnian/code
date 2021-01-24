csharp
using (var sr = new StreamReader(inPath))
{
    using (var sw = new StreamWriter(outPath))
    {
        var reader = new CsvReader(sr);
        var writer = new CsvWriter(sw);
        IEnumerable records = reader.GetRecords<DataRecord>().ToList();
        List<CountAndFrequencyClass> list1 = new List<CountAndFrequencyClass>();
        list1 = CountAndFrequency(records, "ShipperName", 1);
        List<CountAndFrequencyClass> list2 = new List<CountAndFrequencyClass>();
        list2 = CountAndFrequency(records, "ShipperCity", 1);
        for (int i = 0; i < list1.Count; i++)
        {
            writer.WriteRecord(list1[i]);
            writer.WriteRecord(list2[i]);
            writer.NextRecord();
        }
    }
}
