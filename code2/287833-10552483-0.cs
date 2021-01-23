    public class MenuController : Controller
    {
        [ChildActionOnly]
        public ActionResult Header()
        {
            var model = ... // go to the database and fetch a model
            return Partial("_Header", model);
        }
    }
