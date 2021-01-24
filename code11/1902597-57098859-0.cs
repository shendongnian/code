DateTime d1 = new DateTime(2019, 7, 18, 12, 5, 2);
DateTime d2 = new DateTime(2019, 7, 18, 5, 45, 33);
d1.Date == d2.Date
As for the data structure you desire, you can create a new class with corresponding properties:
public class RecordData
{
    public string Date { get; set; }
    public List<Record> Records { get; set; }
}
Then, start adding `RecordData` objects to a list:
List<RecordData> RecordDatas = new List<RecordData>();
Using LINQ statements similar to this (assuming we have list of records from EF named `records` and a start date named `startDate`):
RecordDatas.Add(new RecordData
{
    Date: "StartDate",
    Records: records.Where(r => r.Date.Date == startDate.Date).ToList();
}
And finally, use a library (such as Newtonsoft Json.NET) to serialize the `RecordData` list to JSON:
string output = JsonConvert.SerializeObject(RecordDatas);
