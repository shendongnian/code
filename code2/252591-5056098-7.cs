    public class BackgroundController : Controller
    {
        public ActionResult Export(int id)
        {
            Task.Factory.StartNew(() => DoLengthyOperation(id));
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
