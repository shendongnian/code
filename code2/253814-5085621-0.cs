    public class MvcApplication : System.Web.HttpApplication
    {
    	//---snip---
    	
    	protected void Application_BeginRequest(object sender, EventArgs e)
    	{
    		var url = RewriteUrl(Request.Path);
    		
    		Context.RewritePath(url);
    	}
    	
    	//---snip---
    	
    	private string RewriteUrl(string path)
    	{
    		if (!path.Contains("Content") && !path.Contains("Scripts"))
    		{
    			path = path.Replace("-", "");
    		}
    		
    		return path;
    	}
    }
