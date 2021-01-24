    using Microsoft.AspNetCore.Mvc;
    
    namespace BlazorApp13.Server.Controllers
    {
    	public class PersonController : Controller
    	{
    		[HttpPost]
    		public bool IsEmailAddressAvailable([FromBody]RequestWithEmailAddress request)
    		{
    			bool available = (request.EmailAddress ?? "").ToLowerInvariant().IndexOf("available.com") > -1;
    			return available;
    		}
    	}
    
    	public class RequestWithEmailAddress
    	{
    		public string EmailAddress { get; set; }
    	}
    }
