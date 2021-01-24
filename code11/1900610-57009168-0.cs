    services.AddApiVersioning(options => {
    options.AssumeDefaultVersionWhenUnspecified = true;
    });
    [ApiVersion("1.0")] // Add this
    [ApiVersion("2.0")] // Add this
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
    // GET api/values
    [HttpGet]
    // This is used vor API version 1
    public ActionResult<IEnumerable> Get()
    {
    return Get("v1");
    }
    
    // GET api/values
    [HttpGet()]
    [MapToApiVersion("2.0")]
    public ActionResult<IEnumerable> Get(string param = "v2")
    {
    return new string[] { "value1", "value2", param };
    }
    
    // here the rest of the class
    }
