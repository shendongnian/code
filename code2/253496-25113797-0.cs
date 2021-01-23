    public class BasePage : System.Web.UI.Page
    {
    	public BasePage()
    	{
    	}
    	protected override void OnPreInit(EventArgs e)
    	{
    		MasterPageFile = "MasterPage2.master";
    
    	}  
    }
