    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpPost]
        public async Task<ActionResult<Test>> Post(Test machines)
        {
            //do your stuff...
        }
    }
