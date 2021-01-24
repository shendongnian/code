    void Main()
    {
    	var str = "A\nA\n\n\nB\n\nD\nA\n\nE";
    	
    	var before = str.Split(new string[] { "\n" }, StringSplitOptions.None);
    	var after = before.Distinct(new MyComparer());
    	
    	before.Dump();
    	after.Dump();
    }
    
    public class MyComparer : EqualityComparer<string>
    {
    	public override bool Equals(string x, string y)
    	{
    		if(x == "" || y == "")
    			return false;
    		return x.Equals(y);
    	}
    
    	public override int GetHashCode(string obj)
    	{
    		return obj.GetHashCode();
    	}
    }
