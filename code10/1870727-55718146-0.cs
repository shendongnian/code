    public class Road
    {
    	public Road(string val)
    	{
    		Lane = val[0];
    		Number = int.Parse(val.Substring(1));
    	}
    	
    	public char Lane { get; set; }
    	public int Number { get; set; } = 1;
    
    	public static implicit operator Road(string val)
    	{
    		return new Road(val);
    	}
    }
