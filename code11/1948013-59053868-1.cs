    public class UserController : TController<UserModel, UserService>
    {
        public UserController(UserService service): base(service)
        {
        }
    
        [HttpGet("/check")]
        public bool Check()
        {
    
    
            return service.CheckPassword(new UserModel
            {
            });
        }
    
    }
