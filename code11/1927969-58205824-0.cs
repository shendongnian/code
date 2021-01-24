csharp
var columns = GetColumns();
var writeList = new List<dynamic>();
for (int i = 0; i < columns[0].ItemList.Count; i++)
{
    var csvItem = new ExpandoObject() as IDictionary<string, object>;
    csvItem.Add("TimeStamp", columns[0].ItemList[i].TimeStamp.ToString("yyyy/MM/dd HH:mm:ss"));
    foreach (var column in columns)
    {
        csvItem.Add(column.ColName, column.ItemList[i].Value);
    }
    writeList.Add(csvItem);
}
using (var writer = new StreamWriter("output.csv"))
{
    using (var csv = new CsvHelper.CsvWriter(writer))
    {
        csv.WriteRecords(writeList);
    }
}
