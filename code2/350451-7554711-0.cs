    public class ConversionAttribute : ActionFilterAttribute
    {    
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var idValue = filterContext.RouteData.Values["id"];
            var convertedIdValue = ConvertId(idValue);
            var newRouteValues = new RouteValueDictionary(filterContext.RouteData.Values);
            newRouteValues["id"] = convertedIdValue;
            
            filterContext.Result = new RedirectToRouteResult(newRouteValues);
        }
    }
