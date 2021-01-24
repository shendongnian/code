public class ReturnClass
{
    public string name {get; set;}
    public DatTime date {get; set;}
    public string/int value {get; set;}
}
var records = context.data.ToList();
var results = new List<ReturnClass>();
foreach(var record in records)
{
    var date = record.date_start;
    while(date <= record.date_end)
    {
        results.Add(new ReturnClass
        {
            name = record.name,
            date = date,
            value = record.value
        }
        date = date.AddMonths(1);
    }
}
return results;
