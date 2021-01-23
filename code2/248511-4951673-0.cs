    [ComplexType()]
    public class UriHelper
    {
    	public string StringRepresentation {get;set;}
    	public Uri ActualUri()
    	{
    		return new Uri(StringRepresentation);
    	}
    }
