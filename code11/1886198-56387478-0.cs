using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace SomeWebApplication.Controllers
{
    public class SomeController : Controller
    {
        public ActionResult SomeControllerMethod()
        {
            Response.ContentType = Request.AcceptTypes.FirstOrDefault() ?? "text/plain";
            return View();
        }
    }
}
The FirstOrDefault() call will return the first item in Request.AcceptTypes. If Request.AcceptTypes is an empty array, it will return null, the default value of string. If it is null, the ?? operator returns "text/plain" instead of null.
