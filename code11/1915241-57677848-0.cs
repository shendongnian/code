     JObject jsonObject = JObject.Parse(json);
     JToken jToken = JToken.Parse(json);
    
     var result = jToken["movieList"].SelectMany(x => x["showTimes"]).ToList();
    
     foreach (var item in result)
     {
       var times = item.SelectTokens("time").Values().ToList();    
       if (!times.Where(x => x.ToString().Trim() == "18:00").Any())
       {
           item.Remove();
       }
     }
    
     var output = jToken.ToString(Formatting.Indented);   
     Console.WriteLine(output);
