    public class MainController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm]Model model)
        {
            var files = Request.Files;
            var title = model.Title
            //And you can save or use files and content at the same time.
        }
    }
