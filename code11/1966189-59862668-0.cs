    var allPlayerDetails = new List<Dictionary<string, object>>();
    foreach (JObject player in jObject["Players"].Children())
    {
    	var playerDictionary = player.Properties()
    		.ToDictionary<JProperty, string, object>(property => property.Name, property => property.Value);
    
    	allPlayerDetails.Add(playerDictionary);
    }
    
    for (var index = 0; index < allPlayerDetails.Count; index++)
    {
    	var playerDictionary = allPlayerDetails[index];
    	Console.WriteLine(Environment.NewLine);
    	Console.WriteLine(string.Format("Printing Player# {0}", index));
    	foreach (var d in playerDictionary)
    	{
    		Console.WriteLine(d.Key + " - " + d.Value);
    	}
    }
    
