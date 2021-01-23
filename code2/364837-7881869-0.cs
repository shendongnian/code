    public class EnumerationController : Controller {
        // other actions...
        public ActionResult List(){
            // TODO: var model = retrieve-your-model-here
            return PartialView(model);
        }
    }
