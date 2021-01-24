    public IEnumerable<string> Extract(string sourceStr, string startStr, string endStr)
    {
    	var startIndices = IndexOfAll(sourceStr, startStr).ToArray();
    	var endIndices = IndexOfAll(sourceStr, endStr).ToArray();
    	if(startIndices.Length != endIndices.Length)
    		throw new InvalidOperationException("Missmatch");
    		
    	for (int i = 0; i < startIndices.Length; i++)
    	{
    		var start = startIndices[i];
    		var end = endIndices[endIndices.Length - 1 - i];
    		yield return sourceStr.Substring(start, end - start + 1);
    	}
    }
    
    public static IEnumerable<int> IndexOfAll(string source, string subString)
    {
    	return Regex.Matches(source, Regex.Escape(subString)).Cast<Match>().Select(m => m.Index);
    }
