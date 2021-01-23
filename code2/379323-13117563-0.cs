    public class ValidateSubmitOnceTokenAttribute : ActionFilterAttribute
    {
        public String ErrorView { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            String submitOnceToken = null;
            submitOnceToken = filterContext.HttpContext.Request[ViewHelper.SubmitOnceIdentifier];
            if ((bool)filterContext.HttpContext.Session[ViewHelper.SubmitOnceIdentifier + submitOnceToken])
            {
                if (String.IsNullOrEmpty(View))
                {
                    filterContext.Result = new EmptyResult();
                }
                else
                {
                    ViewResult newView = new ViewResult();
                    newView.ViewName = ErrorView;
                    filterContext.Result = newView;
                }
            }
            else
            {
                filterContext.HttpContext.Session[ViewHelper.SubmitOnceIdentifier + submitOnceToken] = true;
            }
        }
    }
    public partial class ViewHelper
    {
        internal const string SubmitOnceIdentifier = "_SUBMIT_ONCE_";
        public static MvcHtmlString SubmitOnceToken()
        {
            Guid submitOnceToken = Guid.NewGuid();
            HttpContext.Current.Session[SubmitOnceIdentifier + submitOnceToken] = false;
            return new MvcHtmlString("<input type=\"hidden\" name=\"" + SubmitOnceIdentifier + "\" value=\"" + submitOnceToken.ToString() + "\">");
        }
    }
