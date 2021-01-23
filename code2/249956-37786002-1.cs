    public class FooController : Controller
    {
        public IActionResult Get()
        {
            return Json(new {Bar = "Bar", Baz = "Baz"});
        }
    }
