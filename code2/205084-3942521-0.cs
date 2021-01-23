    public static class WebClientExtension
    {
    	public static void AddArray(this WebClient webClient, string key, params string[] values)
    	{
    		int index = webClient.QueryString.Count;
    
    		foreach (string value in values)
    		{
    			webClient.QueryString.Add(key + "[" + index + "]", value);
    			index++;
    		}
    	}
    }
