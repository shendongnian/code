    In your code checking for this isn't done correctly.  Specifically, I believe at the minimum an `else` is missing in the following location:
		foreach (KeyValuePair<string, JToken> sub in node)
		{
			if (sub.Value.Type == JTokenType.Array)
			{
				// unnamed nodes which contain nested objects 
				if (sub.Value.First.Type == JTokenType.Object)
				{
					foreach (var innerNode in sub.Value.Children())
					{
						documentProperties.UnionWith(ParseJObject((JObject)innerNode));
					}
				}
				else // ELSE WAS REQUIRED HERE
				{
					documentProperties.Add(CreateDocumentProperty(sub.Value));
				}
			}
			else if (sub.Value.Type == JTokenType.Object)
			{
				documentProperties.UnionWith(ParseJObject((JObject)sub.Value));
			}
		}
    Demo fiddle #2 [here](https://dotnetfiddle.net/Jmopo8).
