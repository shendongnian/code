csharp
    public class ITTestController : Umbraco.Web.Mvc.UmbracoController
    {
        [Authorize(Roles = "admingroup")]
        public ActionResult Index()
        {
            return View("/Views/ITTest/Index.cshtml");
        }
    }
