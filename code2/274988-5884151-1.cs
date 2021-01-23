    public class ErrorsController : Controller
    {
        public ActionResult General(Exception exception)
        {
            ViewBag.ErrorCode = Response.StatusCode;
            ViewBag.Message = "Error Happened";
            //you should log your exception here
            return View("Index");
        }
        public ActionResult Http404()
        {
            ViewBag.ErrorCode = Response.StatusCode;
            ViewBag.Message = "Not Found";
            return View("Index");
        }
        public ActionResult Http403()
        {
            ViewBag.Message = Response.StatusCode;
            ViewBag.Message = "Forbidden";
            return View("Index");
        }
    }
