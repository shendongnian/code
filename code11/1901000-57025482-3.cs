    [RoutePrefix("api/ApiDevTool")]
    public class ApiDevToolController : ApiController
    {
    	private bool IsValid { get; set; }
    
    	[HttpGet]
    	[Route("IsStoreKeyValid")]
    	public string IsStoreKeyValid(string storeName, string storeKey)
    	{
    		
    	}
    
    	//get list of pageids
    	[HttpGet]
    	[Route("GetPageIds")]
    	public string GetPageIds(string storeName, string storeKey)
    	{
    		
    	}
    }
