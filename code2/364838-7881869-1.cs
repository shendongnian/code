    public class EnumerationController : Controller {
        // other actions...
        public ActionResult List(){
            // TODO: var model = retrieve-your-model-here
            return PartialView(model);
            // using "PartialView" instead of "View" method ensures this action isn't 
            // responsible from direct requests
            // Also you can use "PartialViewResult" class as a return-type instead
            // of "ActionResult" in method, like "List2()" method below:
        }
        public PartialViewResult List2(){
            // TODO: var model = retrieve-your-model-here
            return PartialView(model);
        }
    }
