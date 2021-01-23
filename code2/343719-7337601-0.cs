     public class SomeController : Controller {
        public ActionResult TagCloud() {
            var model = // fetch data for tagcloud
            return View("~/Views/Shared/Tagcloud.ascx", model);
        }
     }
