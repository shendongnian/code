    public class FormsUserContext : IUserContext
    {
        private readonly IUserRepository _userRepository;
        public FormsUserContext(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User GetUser()
        {
            return _userRepository.GetByUserName(HttpContext.Current.Request.User.Identity.Name);
        }
    }
