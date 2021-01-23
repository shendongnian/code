    public class ValidateHashQuery : IValidateHashQuery
    {
        public bool Validate(string  username, string password)
        {
            ISession nhSession = NHibernateSession.Current;
            // you now have your session and run your query however you like
        }
    }
    public class UserTasks : IUserTasks
    {
        private readonly IRepository<User> _userRepository;
        private readonly IValidateHashQuery _validateHashQuery;
         
        public UserTasks(IRepository<User> userRepository, IValidateHashQuery         validateHashQuery)
        {
            _userRepository = userRepository;
            _validateHashQuery = validateHashQuery;
        } 
    
        public List<User> GetAll()
        {
            return _userRepository.GetAll().ToList();
        }
        public User Get(int id)
        {
            return _userRepository.Get(id);
        }
        public User CreateOrUpdate(User user)
        {
            return _userRepository.SaveOrUpdate(user);
        }
        public void Delete(int id)
        {
            var entity = _userRepository.Get(id);
            if(entity != null)
            {
                _userRepository.Delete(entity);
            }
        } 
        public bool Validate(string username, string password)
        {
            return _validateHashQuery.Validate(username, password);
        }
    }
