    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            DateTime[] holidays = new DateTime[]
                { 
                    new DateTime(2019, 10, 14),
                    new DateTime(2019, 11, 11),
                    new DateTime(2019, 11, 28),
                };
            return Ok(holidays);
        }
        }        
    }
