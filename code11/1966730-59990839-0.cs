    [ApiController]
    public class AdWordsController : ControllerBase
    {
        [HttpPost("/Metrics/")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetMetrics(dynamic data)
        {
            return new JsonResult(Metrics((String)data.customerId, (String)data.from, (String)data.to));
        }
