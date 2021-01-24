    var results = JsonConvert.DeserializeObject<List<Dictionary<string,object>>>(json);
    
    foreach (var model in results)
    {
        foreach(var item in model)
        {
            if (item.Key.Contains("ctPoint"))
            {
                var ctPoint = JsonConvert.DeserializeObject<CtPoint>(item.Value.ToString());
                Console.WriteLine($"{item.Key}- {ctPoint.hours} {ctPoint.startTemperature} {ctPoint.endTemperature}");
            }
            else if (item.Key.Contains("duration"))
            {
                var duration = JsonConvert.DeserializeObject<Duration>(item.Value.ToString());
                Console.WriteLine($"{item.Key}- {duration.days} {duration.hours}");
            }
            else
            {
                Console.WriteLine($"{item.Key}- {item.Value.ToString()}");
            }
        }
    }
