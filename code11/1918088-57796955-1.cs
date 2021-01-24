    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase {
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get() {
            await Task.Delay(1000);
            return new string[] { "value1", "value2" };
        }
    }
