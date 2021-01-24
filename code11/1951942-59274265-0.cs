    [Route("my/")]
    public class MyController : Controller
    [HttpGet]
    [AllowAnonymous]
    [Route("")] //prefer this if we asked for this action
    [Route("index", Order = 1)]
    [Route("default.aspx", Order = 100)] // legacy might as well get an order of 100
    public async Task<IActionResult> GetIndex()
    {
    }
   
