    public static class ListExtension
    {
    	public static int GetIndex<T>(this List<T> list, T value, int skipMatches = 1)
    	{
    		for (int i = 0; i < list.Count; i++)
    			if (list[i].Equals(value))
    			{
    				skipMatches--;
    				if (skipMatches == 0)
    					return i;
    			}
    		return -1;
    	}
    }
    
    List<int> list = new List<int>();
    list.Add(3);
    list.Add(4);
    list.Add(5);
    list.Add(4);
    int secondFour = (int)list.GetIndex(4, 2);
