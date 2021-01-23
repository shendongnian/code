    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext context)
        {
            HttpCookie myCookie = Request.Cookies[keyOfSomeKind];
            if (myCookie == null)
            {
                HttpCookie newCookie
                    = new HttpCookie(keyOfSomeKindy, "Some message");
                newCookie.Expires = DateTime.Now.AddMinutes(3);
                current.Response.Cookies.Add(newCookie);
            }
            base.OnActionExecuting(context);
        }
    }
