    public class MyPage : Page
    {
    	public string CurrentUrl
    	{
    		get
    		{
    			return Request.Url.ToString().ToLower();
    		}
    	}
    }
