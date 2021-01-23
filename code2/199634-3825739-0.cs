    public class MailAddress
    {
    	public MailAddress(string emailAddress, string displayName)
    	{
    		_DisplayName = displayName;
    		_EmailAddress = emailAddress;
    	}
    	public MailAddress()
    	{
    		_DisplayName = "";
    		_EmailAddress = "";
    	}
    
    	private string _DisplayName;
    	public string DisplayName
    	{
    		get { return _DisplayName; }
    		set { _DisplayName = value; }
    	}
    
    	private string _EmailAddress;
    	public string EmailAddress
    	{
    		get { return _EmailAddress; }
    		set { _EmailAddress = value; }
    	}
    
    	public override string ToString()
    	{
    		return DisplayName;
    	}
    }
