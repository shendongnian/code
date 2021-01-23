    using System.Linq;
    using System.Web.Mvc;
    
    namespace YourNamespace.Web.Application.Models
    {
        public class LanguageCodeActionFilter : ActionFilterAttribute
        {
            // This checks the current langauge code. if there's one missing, it defaults it.
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                const string routeDataKey = "languageCode";
                const string defaultLanguageCode = "sv";
                var validLanguageCodes = new[] {"en", "sv"};
    
                // Determine the language.
                if (filterContext.RouteData.Values[routeDataKey] == null ||
                    !validLanguageCodes.Contains(filterContext.RouteData.Values[routeDataKey]))
                {
                    // Add or overwrite the langauge code value.
                    if (filterContext.RouteData.Values.ContainsKey(routeDataKey))
                    {
                        filterContext.RouteData.Values[routeDataKey] = defaultLanguageCode;
                    }
                    else
                    {
                        filterContext.RouteData.Values.Add(routeDataKey, defaultLanguageCode);    
                    }
                }
    
                base.OnActionExecuting(filterContext);
            }
        }
    }
