    void Main()
    {
    	var colors = new Color[] { Color.Red, Color.Blue, Color.Gray };
    	Array.Sort(colors, new RedColorComparer());
    	colors.Dump();
    }
    
    public class RedColorComparer : IComparer<Color>
    {
    	public int Compare(Color a, Color b)
    	{
    	   	if (a.R < b.R)
    	   		return 1;
    		else if (a.R == b.R)
    			return 0;
    		else 
    			return -1;
    	}
    }
