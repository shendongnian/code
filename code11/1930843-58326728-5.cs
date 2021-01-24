    public class FirstLetterComparer : IEqualityComparer<string>
    {
    	public bool Equals(string s1, string s2)
    	{
    		if (s1 == null && s2 == null) 
    			return true;
    		if (s1 == null || s2 == null)
    			return false;
    		return (s1[0] == s2[0]);
    	}
    
    	public int GetHashCode(string s)
    	{
    		return s == null ? 0 : s[0].GetHashCode();
    	}
    }
    public static class X
    {
    	public static long MsTicks(this int i)
    	{
    		return TimeSpan.FromMilliseconds(i).Ticks;
    	}
    }
