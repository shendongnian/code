    public class FetchStub : Fetch
    {
    	private readonly string _colorCode;
    	public FetchStub(string colorCode)
    	{
    		_colorCode = colorCode;		
    	}
    
    	public override string GetColorCodes()
    	{
    		return _colorCode;
    	}
    }
    
    
    public class Fetch
    {
    
    	public Fetch()
    	{
    		//I dont have any dependency injection
    	}
    
    	public virtual string GetColorCodes()
    	{
    		return "Yellow";
    	}
    
    	public string FetchData()
    	{
    		string color = GetColorCodes();
    		return color;
    	}
    }
