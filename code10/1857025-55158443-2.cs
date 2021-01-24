    public class AccountController
    {
    	public IConfiguration _configuration { get; }
    
        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    	
    	[HttpPost]
    	[Route("CreateUser")]
    	public IActionResult CreateUser(string conn, string username)
    	{
    		try
    		{
    			AccountDL objAccountDL = new AccountDL(_configuration); //call account data layer
    			objAccountDL.CreateUser(conn, username); //conn = "CON1"
    			return Ok();
    		}
    		catch(Exception ex)
    		{
    			throw ex;
    		}
    	}
    }
