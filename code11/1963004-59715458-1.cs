    #if NETCORE
    using Microsoft.AspNetCore.Mvc.Filters;
    #else
    using System.Web.Mvc;
    #endif
    
    namespace SharedFilter
    {
        public class MyFilter : IActionFilter
        {
            public void OnActionExecuting(ActionExecutingContext context)
            {
                throw new System.NotImplementedException();
            }
    
            public void OnActionExecuted(ActionExecutedContext context)
            {
                throw new System.NotImplementedException();
            }
        }
    }
