    public static class ArrayExtensions
    {
    	public static bool ElementsEqual<T>(this T[] left, T[] right)
    		where T : IEquatable<T>
    	{
    		if (left == null || right == null)
    		{
    			return !(left == null ^ right == null);
    		}
    		else if (left.Length != right.Length)
    		{
    			return false;
    		}
    
    		for (int i = 0; i < left.Length; i++)
    		{
    			if (!left[i].Equals(right[i]))
    			{
    				return false;
    			}
    		}
    
    		return true;
    	}
    }
