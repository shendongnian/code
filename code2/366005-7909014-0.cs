    public class ControllerBase : Controller
    {
        //authorization group setting an menu creation here.
        //set properties and objects to ViewBag items to access from the front end.
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
