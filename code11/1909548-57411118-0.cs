    [Route("api/[controller]")]
    [ApiController]
    public class ReposController : ControllerBase
    {
       //GetAll api/repos
       public IEnumerable<Employees> Getall()
       {
       //Your code
       }
        //GET api/repos/id
        [HttpGet("{id}", Name = "Getid")]
        public Employees GetEmployees(int id)
        {
        //Your code
        }
    }
