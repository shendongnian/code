    public class ApplicationsController : ControllerExtended
    {
        // GET: /Applications/Index
        public ActionResult Index() {
            this.DetectMobileDevices();
            if(this.IsMobile){
                return RedirectToAction("MobileIndex");
            } else {
                // actual action code goes here
                return View();
            }            
        }
    }
