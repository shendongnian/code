    [Route("api/[controller]")]
    public class ListController : Controller
    {        
        [HttpPost("test/{name}")]
        public string Post([FromRoute] string name)
        {
            return "Name: " + name;
        }
    }
