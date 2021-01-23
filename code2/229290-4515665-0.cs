    public class CustomActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var response = filterContext.HttpContext.Response;
                
            response.Write(filterContext.ActionDescriptor.ActionName);
            response.Write("<br/>");
    
            foreach (var parameter in filterContext.ActionParameters)
            {
                response.Write(string.Format("{0}: {1}", parameter.Key, parameter.Value));
            }
        }
    }
    [CustomActionFilter]
    [HttpPost]
    public ViewResult Test(ItemModel model)
    {
        return View(model);
    }
