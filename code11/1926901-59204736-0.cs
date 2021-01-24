    public class BasePage : Page
    {
    	public virtual string GetVirtualUrl()
    	{
    		throw new NotImplementedException();
    	}
    
    	public void PageRedirect<T>() where T : BasePage, new()
    	{
    		T page = new T();
    		Response.Redirect(page.GetVirtualUrl());
    	}
    }
    
    public partial class OnePage : BasePage
    {
    	protected void Page_Load()
    	{
    		// Redirect to two.aspx
    		PageRedirect<TwoPage>();
    	}
    }
    
    public partial class TwoPage : BasePage
    {
    	public override string GetVirtualUrl()
    	{
    		return "~/two.aspx";
    	}
    }
