    public class HereController: Controller
    {    
        public ActionResult RedundantLogic()
        {
            ...
            return View();
        }
        public ActionResult ComeHere()
        {
            ...
            return RedirectToAction("RedundantLogic");
        }
    }
    public class ThereController: Controller
    {
        public ActionResult ComeOverHere()
        {
            ...
            return RedirectToAction("RedundantLogic", "Here");
        }
    }
