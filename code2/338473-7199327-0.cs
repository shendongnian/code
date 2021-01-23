    public class SellerMembershipProvider : IMembershipProvider
    {
      public bool Authorize(string email, string password)
      {
        // validate seller
      }
    }
    
    public class BuyerMembershipProvider : IMembershipProvider
    {
      public bool Authorize(string email, string, password)
      {
        // validate buyer
      }
    }
    
    public class MembershipProviderFactory
    {
      public IMembershipProvider Create(string email)
      {
         if(/* email is in seller database*/)
         {
           return new SellerMembershipProvider();
         }
         else
         {
           return new BuyerMembershipProvider();
         }
      }
    }
    
    public class LoginController : Controller
    {
    
      private readonly MembershipProviderFactory _providerFactory = new MembershipProviderFactory();
      public ActionResult Authenticate(string email, string password)
      {
    
        IMembershipProvider provider = _providerFactory.Create(email);
        if(provider.Authorize(email, password))
        {
    	return View("MyAccount");
        }
        else
        {
            return View("Login");
        }
      }
    }
