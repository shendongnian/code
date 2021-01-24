    var results = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);
    
    //DE Dictionary
    var deDict = results.SelectMany(x => x).ToDictionary(x => x.Key, x => JObject.Parse(x.Value.ToString())["de-DE"] == null ? "" : JObject.Parse(x.Value.ToString())["de-DE"].ToString());
    
    //FR Dictionary
    var frDict = results.SelectMany(x => x).ToDictionary(x => x.Key, x => JObject.Parse(x.Value.ToString())["fr-FR"] == null ? "" : JObject.Parse(x.Value.ToString())["fr-FR"].ToString());
    
    //DE Dictionary     
    foreach (var keyvalue in deDict)
    {
        Console.WriteLine($"{keyvalue.Key} : {keyvalue.Value}");
    }
    
    //FR Dictionary
    foreach (var keyvalue in frDict)
    {
        Console.WriteLine($"{keyvalue.Key} : {keyvalue.Value}");
    }
