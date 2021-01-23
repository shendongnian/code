    public class ErrorsController : Controller
    {
        public ActionResult Fault(Exception ex)
        {
            var newCookie = new HttpCookie("key", "Exception Exists");
            newCookie.Expires = DateTime.Now.AddYears(Dfait.Environment.RemedyCacheDuration);
            Response.Cookies.Add(newCookie);
 
            // You could return a view or something here
            return Content("OOPS", "text/plain");
        }
    }
