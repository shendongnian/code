    public static IEnumerable<string> SplitExcelRow(this string value)
    {
    	value = value.Replace("\"\"", "&quot;");
    	bool quoted = false;
    	int currStartIndex = 0;
    	for (int i = 0; i < value.Length; i++)
    	{
    		char currChar = value[i];
    		if (currChar == '"')
    		{
    			quoted = !quoted;		
    		}
    		else if (currChar == ',')
    		{
    			if (!quoted)
    			{
    				yield return value.Substring(currStartIndex, i - currStartIndex)
    					.Trim()
    					.Replace("\"","")
    					.Replace("&quot;","\"");
    				currStartIndex = i + 1;
    			}
    		}
    	}
    	yield return value.Substring(currStartIndex, value.Length - currStartIndex)
    		.Trim()
    		.Replace("\"", "")
    		.Replace("&quot;", "\"");
    }
