var newData = (from dt in data
                where (((DateTime)dt["END"]).Hour == 0 && ((DateTime)dt["END"]).Minute == 0 && ((DateTime)dt["END"]).Second == 0)
                select new Dictionary<string, object>(dt.ToDictionary(kvp => kvp.Key, kvp => kvp.Key == "END" ? ((DateTime)kvp.Value).AddHours(23).AddMinutes(59).AddSeconds(59) : kvp.Value))
                ).ToList();
                
for (int i = 0; i < newData.Count; i++)
    Console.WriteLine(newData[i]["END"].ToString());
Here is the same thing, just written a different way. Take your pick as to what is more readable.
var newData = data.Where(dt => ((DateTime)dt["END"]).Hour == 0 && ((DateTime)dt["END"]).Minute == 0 && ((DateTime)dt["END"]).Second == 0)
                    .Select(dt => new Dictionary<string, object>(dt.ToDictionary(kvp => kvp.Key, kvp => kvp.Key == "END" ? ((DateTime)kvp.Value).AddHours(23).AddMinutes(59).AddSeconds(59) : kvp.Value)))
                    .ToList();
