    public IEnumerable<Result> GetResult(string json)
    {
    	var parsedResult = JsonConvert.DeserializeObject<List<dynamic>>(json);
    	
    	if(parsedResult.OfType<JArray>().Any()) 
    	{
    		for(var i=0;i<parsedResult.OfType<JArray>().First().Count();i++)
    		{
    			var returnValue = new Result();
    			returnValue.SearchTerm = parsedResult.First();
    			returnValue.Key = parsedResult.Skip(1).First()[i].Value;
    			returnValue.Description = parsedResult.Skip(2).First()[i].Value;
    			returnValue.Url = parsedResult.Skip(3).First()[i].Value;
    			yield return returnValue;
    		}
    	}
    	else
    		yield return null;
    }
