    - In Controller define 2 function for desktop & iPhone, they have the same ActionName
    
        [iPhone]
        [ActionName("Index")] 
        public ActionResult Index_iPhone() { /* Logic for iPhones goes here */ }     
        [ActionName("Index")]
        public ActionResult Index_PC() { /* Logic for other devices goes here */ }
    	
    - Define [iPhone] action method selector:    	    
        public class iPhoneAttribute : ActionMethodSelectorAttribute 
        	{ 
        		public override bool IsValidForRequest(ControllerContext controllerContext,  
        											   MethodInfo methodInfo) 
        		{ 
        			var userAgent = controllerContext.HttpContext.Request.UserAgent; 
        			return userAgent != null && userAgent.Contains("iPhone"); 
        		} 
        	}
