    public class MyMailAddress : MailAddress
    {
    	
    	public MyMailAddress(string emailAddress, string displayName) : base(emailAddress, displayName)
    	{
    		
    	}
    	public override string ToString()
    	{
    		return base.DisplayName;
    	}
    }
