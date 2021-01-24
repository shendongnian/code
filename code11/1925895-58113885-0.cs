     public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        public UsersController(UserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost]
        public IActionResult PostUser(User user)
        {
            _userService.AddUser(user);
            return Ok();
        }
    }
