 csharp
namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = 3)]
        public ActionResult Index()
        {
            return View();
        }
    }
}
This code will cache this action for 3 sec and `OutputCache` default `Location` is `Any`(cache clinet and server).
cache in client side:
csharp
namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = 3, Location=OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            return View();
        }
    }
}
cache in server side:
csharp
namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = 3, Location=OutputCacheLocation.Server)]
        public ActionResult Index()
        {
            return View();
        }
    }
}
In addition,adding `VaryByParam` property let cache can vary by parameter. In same action, user use different parameter will get different cache, same parameter get same cache version.
This can use to a cache like product info page.
csharp
namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = 3, VaryByParam = "id")]
        public ActionResult ProductDetail(int id)
        {
            ViewBag.detail = id;
            return View();
        }
    }
}
`OutputCache` has a many property and feature , you can visit [msdn][1] get more info .
  [1]: https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/controllers-and-routing/improving-performance-with-output-caching-cs
