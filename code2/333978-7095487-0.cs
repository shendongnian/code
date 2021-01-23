    public class MyColor {
    	public System.Drawing.Color val;
    
    	public MyColor(System.Drawing.Color color)
    	{
    		this.val = color;
    	}
    	
    	public static MyColor AliceBlue 
    	{
    		get {
    			return new MyColor(System.Drawing.Color.AliceBlue);
    		}
    	}
    	
    	public override string ToString()
    	{
    		return val.ToString();
    	}
    	// .... and so on....
    	
    	// User-defined conversion from MyColor to Color
    	public static implicit operator System.Drawing.Color(MyColor c)
    	{
    		return c.val;
    	}
    	//  User-defined conversion from Color to MyColor
    	public static implicit operator MyColor(System.Drawing.Color c)
    	{
    		return new MyColor(c);
    	}
    }
