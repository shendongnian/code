    var results = System.Text.Json.JsonSerializer.Deserialize<List<Dictionary<string,object>>>(json);
    
    foreach (var model in results)
    {
        foreach(var item in model)
        {
            if (item.Key.Contains("ctPoint"))
            {
                var ctPoint = System.Text.Json.JsonSerializer.Deserialize<CtPoint>(item.Value.ToString());
                Console.WriteLine($"{item.Key}- {ctPoint.hours} {ctPoint.startTemperature} {ctPoint.endTemperature}");
            }
            else if (item.Key.Contains("duration"))
            {
                var duration = System.Text.Json.JsonSerializer.Deserialize<Duration>(item.Value.ToString());
                Console.WriteLine($"{item.Key}- {duration.days} {duration.hours}");
            }
            else
            {
                Console.WriteLine($"{item.Key}- {item.Value.ToString()}");
            }
        }
    }
