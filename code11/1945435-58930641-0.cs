    public class ApiResult
    {
        public int ID { get; set; }
        public int Value { get; set; }
        public DateTime TimeStamp { get; set; }
    }
    var result = JsonConvert.DeserializeObject<IList<ApiResult>>(File.ReadAllText("../../../data.json"));
    var AggValues = result.GroupBy(x => new
    {
        x.ID,
        x.TimeStamp.AddMinutes(15).Date,
        x.TimeStamp.AddMinutes(15).Hour,
        x.Value
    }).Select(x => new ApiResult
    {
        ID = x.Key.ID,
        TimeStamp = x.Key.Date.AddHours(x.Key.Hour),
        Value = x.Sum(sum => sum.Value)
    });
    foreach(var i in AggValues)
    {
        Console.WriteLine(i.ID + " " + i.Value + " " + i.TimeStamp);
    }
