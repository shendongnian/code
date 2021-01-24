    public class HelpDocumentActionFilter : ActionFilterAttribute
    {
        string helpDocUrl { get; set; }
        public HelpDocumentActionFilter(string _url)
        {
            helpDocUrl = _url;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //whatever viewbag key you wanted with an opportunity to hit the DB or transform the argument
            filterContext.Controller.ViewBag.HelpUrl = helpDocUrl;
        }
    }
