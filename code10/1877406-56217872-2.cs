    public class MyController : Controller
    {
        [HttpGet]
        [SuperUserFilter]
        public IActionResult MySensitiveAction()
        {
            // Do something sensitive
        }
    }
