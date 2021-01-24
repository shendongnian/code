    public static int GetValue(string text, string keyword)
    {
    	var list = text.Split(' ').ToList();
    
    	for (int x = 0; x < list.Count; x++)
    	{
    		if (list[x].Equals(keyword))
    		{
    			if (int.TryParse(list[x + 1], out int number))
    			{
    				return number;
    			}
    			else
    			{
    				break;
    			}
    		}
    	}
    
    	return 0;
    
    }
