    void Main()
    {
    	dynamic d = new drug();
    	
    	double v1 = d.mar0; //234
    	double v2 = d.mar1; //64
    	double v3 = d.mar2; //34 
    	double v4 = d.mar3; //342
    }
    
    public class drug : DynamicObject
    {
    	private double[] coc = new double[] { 156, 4, 8, 164 };
    	private double[] mar = new double[] { 234, 64, 34, 342 };
    	
    	public override bool TryGetMember(GetMemberBinder binder, out object result)
    	{
    		string name = binder.Name.ToLower();
    		if(name.StartsWith("coc"))
    		{
    			result = coc[int.Parse(name.Replace("coc",""))];
    			return true;
    		}
    		if(name.StartsWith("mar"))
    		{
    			result = mar[int.Parse(name.Replace("mar",""))];
    			return true;
    		}
    		result = -1;
    		return false;
    	}
    }
