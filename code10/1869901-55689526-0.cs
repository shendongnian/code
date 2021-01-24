    public class ValuesController : Controller
    {
        public IActionResult GetValue(int version)
        {
            return new ContentResult { Content = version.ToString() };
        }
    }
