    static string TransformJson(string inputPayload)
    {
    	JObject obj = JObject.Parse(inputPayload);
    	var manipulatedObj = obj.DeepClone();
    	foreach (var child in obj)
    	{
    		var key = child.Key;
    		var t = child.Value["type"];
    		JToken genType;
    		if (!((JObject)child.Value).TryGetValue("dataGeneratorType", out genType))
    		{
    			continue; // genType is not found so, continue with next object.
    		}
    
    		var str = genType.Type == JTokenType.String ? genType.ToString().ToLower() : null;
    		switch (str)
    		{
    			case "range":
    				var r = new Random();
    				if (((string)t).ToLower() == "float")
    				{
    					var s = (float)child.Value["dataGeneratorStart"];
    					var e = (float)child.Value["dataGeneratorEnd"];
    					manipulatedObj[key] = r.NextDouble() * e;
    				}
    				else
    				{
    					var s = (int)child.Value["dataGeneratorStart"];
    					var e = (int)child.Value["dataGeneratorEnd"];
    					manipulatedObj[key] = r.Next(s, e);
    				}
    
    				break;
    			case "array":
    				var arr = child.Value["dataGeneratorArray"];
    				JToken lengthToken;
    				if (!((JObject)child.Value).TryGetValue("length", out lengthToken))
    				{
    					lengthToken = 2.ToString();
    				}
    
    				if ((string)t != "array")
    				{
    					manipulatedObj[key] = arr.OrderBy(a => a).LastOrDefault();
    				}
    				else
    				{
    					var count = arr.Count() >= (int)lengthToken ? (int)lengthToken : arr.Count();
    					var item = new JArray();
    					foreach (var m in Enumerable.Range(0, count).Select(i => arr[i]))
    					{
    						item.Add(m);
    					}
    
    					manipulatedObj[key] = item;
    				}
    
    				break;
    			case "object":
    				var transformJson = TransformJson(child.Value["dataGeneratorValue"].ToString());
    				manipulatedObj[key] = JObject.Parse(transformJson);
    				break;
    			default:
    				manipulatedObj[key] = child.Value["dataGeneratorValue"];
    				break;
    		}
    	}
    
    	return manipulatedObj.ToString(Formatting.Indented);
    }
