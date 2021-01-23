    public static class Extensions
    {
    	public static int[] IndexesOf(this string str, string sub)
    	{
    		int[] result = new int[0];
    		
    		for(int i=0; i < str.Length; ++i)
    		{
    			if(i + sub.Length > str.Length)
    				break;
    			if(str.Substring(i,sub.Length).Equals(sub))
    			{
    				Array.Resize(ref result, result.Length + 1);
    				result[result.Length - 1] = i;
    			}
    		}
    		return result;
    	}
    }
