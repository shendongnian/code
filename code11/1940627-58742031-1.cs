    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
    ....
        [HttpPost("[action]")]
        public string GetStudentData_1(string p1, string p2)
        {
            return p1 + p2;
        }
    }
