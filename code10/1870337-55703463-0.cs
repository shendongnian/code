    string json = "Your json here";
    
    JToken jToken = JToken.Parse(json);
    var result = jToken["contacts"].ToObject<JArray>()
        .Select(x => new
        {
            vid = Convert.ToInt32(x["vid"]),
            properties = x["properties"].ToObject<Dictionary<string, JToken>>()
                                        .Select(y => new
                                        {
                                           Key = y.Key,
                                           Value = y.Value["value"].ToString()
                                        }).ToList()
        }).ToList();
    //-----------Print the result to console------------
    foreach (var item in result)
    {
        Console.WriteLine(item.vid);
    
        foreach (var prop in item.properties)
        {
            Console.WriteLine(prop.Key + " - " + prop.Value);
        }
    
        Console.WriteLine();
    }
