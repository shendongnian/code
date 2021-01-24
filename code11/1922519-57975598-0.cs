    using System.Web.Configuration;
    using System.Web.Mvc;
    
    namespace Mvc.Filters
    {
        public class ExtendedOutputCacheAttribute : OutputCacheAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (!web.config.caching.disabled) // just read the right config setting somewhere 
                {
                   base.OnActionExecuting(filterContext);
                }
            }
        }
    }
