    var random = new Random();
    var dates = new List<DateTime>();
    for (int i = 0; i < 10; i++)
    {
       dates.Add(new DateTime(year: random.Next(2000, 2020), month: random.Next(1, 13), day: random.Next(1, 28)));
    }
    var json = new JObject();
    foreach (var year in dates.GroupBy(d => d.Year).OrderBy(d => d.Key))
    {
        JObject yearJSON = new JObject();
        foreach (var month in year.GroupBy(d=> d.Month).OrderBy(d => d.Key))
        {
           JObject monthJSON = new JObject();
           foreach (var day in month.Select(d=> d.Day).OrderBy(d => d))
           {
                    monthJSON.Add(day.ToString(), new JArray(new JObject()));
           }
           yearJSON.Add(month.Key.ToString(), monthJSON);
       }
       json.Add(year.Key.ToString(), yearJSON);
    }
    Console.WriteLine(json.ToString());
