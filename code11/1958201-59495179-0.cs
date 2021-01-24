    static JObject DeNullifier(JObject inputJson)
    {
    	var nodesToRemove = new List<JToken>();
        //Each school in the results[] section
        foreach(var school in inputJson["results"])
        {
            //Each degree in the cip_4_digit section
            foreach(var degree in school["latest.programs.cip_4_digit"])
            {
                if(string.IsNullOrEmpty(degree["earnings.median_earnings"].Value<string>()))
                {
                    nodesToRemove.Add(degree);
                }
            }
        }
    	
    	foreach(var node in nodesToRemove)
    	{
    		node.Remove();
    	}
        return inputJson;
    }
