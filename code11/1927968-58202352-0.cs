csharp
using (var writer = new StreamWriter("output.csv"))
{
    using (var csv = new CsvHelper.CsvWriter(writer))
    {
        var columns = GetColumns();
        // Write header
        csv.WriteField("TimeStamp");
        foreach (var column in columns)
        {
            csv.WriteField(column.ColName);
        }
        csv.NextRecord();
        // Write rows
        for (int i = 0; i < columns[0].ItemList.Count; i++)
        {
            csv.WriteField(columns[0].ItemList[i].TimeStamp.ToString("yyyy/MM/dd HH:mm:ss"));
            foreach (var column in columns)
            {
                csv.WriteField(column.ItemList[i].Value);
            }
            csv.NextRecord();
        }
    }
}
