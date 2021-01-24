    namespace StocksApi2.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class SymbolDetailsController : ControllerBase
        {
            private readonly IAlphavantageClient _client;
            public SymbolDetailsController(IAlphavantageClient client)
            {
                _client = client;
            }
     
            [HttpGet]
            public async Task<ActionResult> Get([FromQuery]string function = "TIME_SERIES_INTRADAY",
                [FromQuery]string symbol = "MSFT", [FromQuery]string interval = "5min")
            {
           
                try {
                    string query = $"function={function}&symbol={symbol}&interval={interval}";
                    string result = await _client.GetSymboleDetailes(query);
                    return Ok(result);
                }catch(Exception e)
                {
                    return NotFound("Error: " + e);
                }
           
            }
        }
    }
