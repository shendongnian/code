    public class Global : System.Web.HttpApplication
    {
    	public string currentUrl
    	{
    		get
    		{
    			return Request.Url.ToString().ToLower();
    		}
    	}
    }
