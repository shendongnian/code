    public class ISO639Code
    {
    	public string Value { get; set ; }
    	public string Code { get; set; }
    
    	public ISO639Code()
    	{
    		this.Value = "";
    		this.Code = "";
    	}
    
    	public ISO639Code(string value, string code)
    		: this()
    	{
    		this.Value = value;
    		this.Code = code;
    	}
    
    	public override bool Equals(object obj)
    	{
    		if (obj != null)
    		{
    			if (obj is string)
    				return obj.ToString().Equals(this.Value, StringComparison.CurrentCultureIgnoreCase);
    			if (obj is ISO639Code)
    				return ((ISO639Code)obj).Value.Equals(this.Value, StringComparison.CurrentCultureIgnoreCase);
    		}
    		return false;
    	}
    
    	public override int GetHashCode()
    	{
    		return this.Value.GetHashCode();
    	}
    
    	public override string ToString()
    	{
    		return this.Value;
    	}
    }
