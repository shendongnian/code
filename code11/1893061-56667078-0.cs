    [Route("page")]
    public class PagesController : Controller
    {
        // you may also use [HttpGet("{pageName}", Name = "PagePath")] instead,
        // to explicitly match HTTP GET requests
        [Route("{pageName}", Name = "PagePath")]
        public IActionResult GetPage(string pageName)
        {
            switch(pageName?.ToLower())
            {
                case "home":
                    return View("Page", homeModel);
                case "home":
                    return View("Load", loadModel);
                case "home":
                    return View("Blog", blogModel);
                default:
                    return NotFound();
            }
        }
    }
