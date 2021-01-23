    public class AdminRegisterNewUserPresenter : BasePresenter
    {
    	private readonly IUserRegistrationView view = null;
    	public AdminRegisterNewUserPresenter(IUserRegistrationView view) { this.view = view; }
    
    	public void RegisterNewUser()
    	{
    		try 
    		{
    			UserBusinessService service = new UserBusinessService();
    			service.AdminRegisterNewUser(this.view.FirstName, 
    				this.view.LastName, this.view.EmailAddress, this.view.Password);
    		} 
    		catch(Exception e)
    		{
    			base.HandleError(e);
    		}
    	}
    }
    
    public class SelfRegistrationPresenter : BasePresenter
    {
    	private readonly ISelfRegistrationView view = null;
    	public SelfRegistrationPresenter(ISelfRegistrationView view) { this.view = view; }
    
    	public void RegisterNewUser()
    	{
    		try 
    		{
    			UserBusinessService service = new UserBusinessService();
    			service.NewUserSelfRegistration(this.view.FirstName, 
    				this.view.LastName, this.view.EmailAddress, this.view.Password, 
    				this.view.CreditCardNumber, this.view.CreditCardType, this.view.CreditCardExpirationDate);
    		} 
    		catch(Exception e)
    		{
    			base.HandleError(e);
    		}
    	}
    }
