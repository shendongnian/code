    public class MyObjectConverter
    {
    	public MyObjectConverter() : base()
    	{
    	}
    	public MyObjectConverter(string oValue) : this()
    	{
    		this.Value = oValue;
    	}
    	public object Value { get; set; }
    	public override string ToString()
    	{
    		if (this.Value == null)
    		{
    			return string.Empty;
    		}
    		else
    		{
    			return this.Value.ToString();
    		}
    	}
    }
