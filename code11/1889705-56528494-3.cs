    [Route("api/[controller]")]
    public class YourController : BaseController
    {
        [HttpGet("{application}")]
        public IActionResult Get(string application)
        {
            if (application == "Application1")
            {
                ...Application1 called
            }
            if (application == "Application2")
            {
                ...Application2 called
            }
            ...        
        } 
    }
