csharp
    public class ITTestController : Umbraco.Web.Mvc.UmbracoController
    {
        [Authorize(Roles = "someGroup")]
        public ActionResult Index()
        {
            return View("/Views/ITTest/Index.cshtml");
        }
    }
 where `someGroup` is the Umbraco group you wish to allow.
