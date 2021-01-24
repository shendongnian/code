    [RoutePrefix("side-navigation")]
    public class SideNavigationController : BaseController
    {
        [Route("{*pathname}")]
        public ActionResult Index(string pathname)
        {
        }
    }
