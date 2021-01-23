    public class ProfileController : BaseController
    {
        public ActionResult HeaderNav()
        {
            var model = new Models.HeaderModel
            {
                NavigationHtml = HttpContext.Application["HeaderNav"] as string
            };
            return PartialView("_Header", model);
        }
    }
