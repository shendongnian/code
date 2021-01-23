    public class BackgroundController : Controller
    {
        public ActionResult Export(int id)
        {
            // Fire and forget some lengthy operation
            Task.Factory.StartNew(() => DoLengthyOperation(id));
            // return immediately
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
