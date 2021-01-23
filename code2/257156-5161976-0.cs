    var filterList = new Dictionary<string, string>
                                   {
                                        {"ACRating", "Property"},
                                        {"Axles", "Property"}
    									{"SafetyCodes","List"}
    									{"BuiltInFeatures","List"}
                                   };	
    	
                    foreach(KeyValuePair<string,string> i in filterList)
                    {
                        var filter = i.Key;
    					var xList = Vehicles.FilterSpecList(filter);
    					if (i.Value == "List")
    					{
    						foreach (var j in xList)
                            {
    							switch(j.FeatureName)
    							{
    							case "BuiltInFeatures"
    							{
    									v.BuiltInFeatures = "x," + "y";
    									break;
    							}
    					}
    					else if(i.Value == "Property")
    					{
    				foreach (var j in xList)
                            {
                            switch(j.FeatureName)
                                {					
                                    case "ACRating":
    									v.AcRating = j.Value;
                                        Console.WriteLine(j.ToString());
                                        break;
    							}
    					}
