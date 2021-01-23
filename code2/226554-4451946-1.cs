    public class ModelFactory : IModelFactory
    {
    
        private IUserRepository userRepository;
    
        public ModelFactory(IUserRepository userRepository)
        {
             // Inject a repository .. or a service...
             this.userRepository = userRepository;
        }
    
        public T Create<T>() where T : MasterModel, new()
        {
            var m = new T()
            {
                NumberOfMessages = this.userRepository.GetNumberMessages(currentUser) // Get current user somehow... HttpContext
            };
            return m;
        
        }
    }
