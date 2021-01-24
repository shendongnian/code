    [Route("api/[controller]")]
    [ApiController]
    public class NodaTimeController
    {
        [HttpGet]
        public NodaTimeDataStructure Get() => new NodaTimeDataStructure();
    }
