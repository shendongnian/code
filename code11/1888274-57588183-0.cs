    [Route("MyApplication")]
    public class MyController : Controller
    {
    	//You can have multiple routes on an action
    	[Route("")] /MyApplication
    	[Route("/test")] you have move to the /MyApplication/test 
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            //Your Code Session
        }
    }
