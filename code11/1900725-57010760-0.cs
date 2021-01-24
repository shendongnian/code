    public class CatchAllController : Controller
    {
        [Route("{*url}", Order = 999)]
        public IActionResult CatchAll()
        {
            return RedirectPermanent("http://localhost:5555");
        }
    }
