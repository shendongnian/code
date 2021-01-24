    static void Main(string[] args)
    {
    	string jsonText = File.ReadAllText(jsonfilename);
    
    	var jToken = JToken.Parse(jsonText);
    
    	var replaced = FindAndReplace(jToken, "title", "replacewiththis");
    
    	var final = replaced.ToString(Formatting.Indented);
    
    	Console.ReadLine();
    }
    public static JToken FindAndReplace(JToken jToken, string key, JToken value, int? occurence = null)
    {
    	var searchedTokens = jToken.FindTokens(key);
    	int count = searchedTokens.Count;
    
    	if (count == 0)
    		return $"The key you have to search is not present in json, Key: {key}";
    
    	foreach (JToken token in searchedTokens)
    	{
    		if (!occurence.HasValue)
    			jToken.SetByPath(token.Path, value);
    		else
    		if (occurence.Value == searchedTokens.IndexOf(token))
    			jToken.SetByPath(token.Path, value);
    	}
    
    	return jToken;
    }
    public static class JsonExtensions
    {
    	public static void SetByPath(this JToken obj, string path, JToken value)
    	{
    		JToken token = obj.SelectToken(path);
    		token.Replace(value);
    	}
    
    	public static List<JToken> FindTokens(this JToken containerToken, string name)
    	{
    		List<JToken> matches = new List<JToken>();
    		FindTokens(containerToken, name, matches);
    		return matches;
    	}
    
    	private static void FindTokens(JToken containerToken, string name, List<JToken> matches)
    	{
    		if (containerToken.Type == JTokenType.Object)
    		{
    			foreach (JProperty child in containerToken.Children<JProperty>())
    			{
    				if (child.Name == name)
    				{
    					matches.Add(child.Value);
    				}
    				FindTokens(child.Value, name, matches);
    			}
    		}
    		else if (containerToken.Type == JTokenType.Array)
    		{
    			foreach (JToken child in containerToken.Children())
    			{
    				FindTokens(child, name, matches);
    			}
    		}
    	}
    }
