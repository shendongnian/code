     //[Route("api/[controller]")]
    //[ApiController]
    public class DefaultController : ControllerBase
    {
        public  ActionResult<string> Index()
        {
            return "value";
        }
        //[HttpGet("{id}")]
        public ActionResult<int> GetById(int id)
        {
            return id;
        }
    }
