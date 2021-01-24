    [Route("blog")]
    public class BlogController : Controller
    {
        [Route("{categorySlug}", Name = "BlogRoute")]
        public async Task<IActionResult> Category([FromRoute] string categorySlug, [FromQuery] int page) {
    //..
    }
