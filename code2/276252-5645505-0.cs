    public class MyPageClass : Page
    {
    	protected override void OnLoad(EventArgs e)
    	{
    		// Check to see if the session is valid 
    		// and redirect to login if not
    		if (Session["mySessionVar"] == null 
    		|| Session["mySessionVar"] IS_NOT_VALID) 
    			Response.Redirect("/path/to/login/form/");
    			
    		base.OnLoad(e);
    	}
    }
    
    public partial class MyLoginRequiredPage : MyPageClass
    {
    	.
    	.
    	.
    }
