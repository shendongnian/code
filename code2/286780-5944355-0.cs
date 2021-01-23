    public SomeController(IUserService userService, ILoggingService loggingService)
    {
        UserService = userService;
        LoggingService = loggingService;
    }
    
    public ActionMethod Index()
    {
       // Find all active users, page 1 and 15 records.
        var users = UserService.FindWithIsActive(1, 15);         
        return View(new IndexViewModel(users));
    }
    
    public class UserService : IUserService
    {
        public UserService(IGenericReposistory<User> userRepository, 
                           ILoggingService loggingService)
        {
            Repository = userRepository;
            LoggingService = loggingService;
        }
    
        public IEnumberable<User> FindWithIsActive(int page, int count)
        {
            // Note: Repository.Find() returns an IQueryable<User> in this case.
            //       Think of it as a SELECT * FROM User table, if it was an RDMBS.
            return Repository.Find() 
                .WithIsActive()
                .Skip(page)
                .Take(count)
                .ToList();
        }
    }
