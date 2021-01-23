    public class AlphabeticPriorToNonalphabeticComparer : IComparer<char>
    {
    	public int Compare(char x, char y)
    	{
    		if (x == y) return 0;
    		if (Char.IsLetterOrDigit(x))
    		{
    			if (!Char.IsLetterOrDigit(y)) return -1;
    			return x < y ? -1 : +1;
    		}
    		else
    		{
    			if (Char.IsLetterOrDigit(y)) return +1;
    			return x < y ? -1 : +1;
    		}
    	}
    }
    // ...
    var data = "!ABE$N".ToCharArray().ToList();
    var myComparer = new AlphabeticPriorToNonalphabeticComparer();
    data.Sort(myComparer);
