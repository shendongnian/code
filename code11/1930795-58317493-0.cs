    public class HomeController : Controller
    {
        public IActionResult Get()
        {
            var stream = new FileStream(@"example.pdf", FileMode.Open);
            return new FileStreamResult(stream, "application/pdf");
        }
    }
