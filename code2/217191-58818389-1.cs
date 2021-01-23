    public class ErrorController : Controller
    {
        // GET: Error
        public ViewResult Index()
        {
            Response.StatusCode = 500;
            Exception ex = Server.GetLastError();
            return View("~/Views/Shared/SAAS/Error.cshtml", ex);
        }
        public ViewResult NotFound()
        {
            Response.StatusCode = 404;
            return View("~/Views/Shared/SAAS/NotFound.cshtml");
        }
    }
