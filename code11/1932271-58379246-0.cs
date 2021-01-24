[Route("/api/customControllerName/getCustomMethodName")]
public ActionResult GetCustomAll() {
}
using [Route("/")] ignores the api route addressings.
[Route("api/candidate/attached-file")]
public class AttachedFileController : Controller
    {
        //overriding controller route
        [HttpPost("api/candidate/{id}/attached-file")]
        public async Task<IActionResult> AttachFile(string id, [FromBody] AttachedFile file)
        {
            ...
        }
        //using controller route
        [HttpGet("{id}")]
        public ActionResult Get(string id) {}
        [Route("/api/test/value")]
        public ActionResult GetCustomAll() {
        }
    }
So,By calling api/test/value address GetCustomAll() method will be called.
