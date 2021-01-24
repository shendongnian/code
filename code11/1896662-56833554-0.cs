    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase {
        //...removed for brevity
        //GET api/users/1234
        [Authorize(Roles = "Admin, Manager, User")]
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int id) {
            //...
        }
    }
