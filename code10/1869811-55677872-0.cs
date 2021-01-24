    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase {
        // GET api/city?id=2 //Note id would be optional as a query variable.
        [HttpGet]
        public ActionResult Get(int id) {
            try {
                var city = new { CityName = "Gotham" };
                return Ok(city);
            } catch(Exception ex) {
                return StatusCode(500);
            }
        }
    }
