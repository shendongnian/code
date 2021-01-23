    namespace MyProj
    {
    	public class Global : HttpApplication
    	{
    		protected virtual void Application_Error(object sender, EventArgs e)
    		{
    			Exception ex = Server.GetLastError().GetBaseException();
    		}
    	}
    }
