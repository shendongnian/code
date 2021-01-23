    public static IEnumerable<string> CheckForDuplicated(IEnumerable<string> listString)
    {
    	List<string> duplicateKeys = new List<string>();
    	List<string> notDuplicateKeys = new List<string>();
    	foreach (var text in listString)
    	{
    		if (notDuplicateKeys.Contains(text))
    		{
    			duplicateKeys.Add(text);
    		}
    		else
    		{
    			notDuplicateKeys.Add(text);
    		}
    	}
    	return duplicateKeys;
    }
