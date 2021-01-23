    public class UserCreationService : IUserCreationService
    {
        private readonly IUserRepository _repository;
        private readonly IUserMailer _userMailer;
        public UserCreationService(IUserRepository repository, IUserMailer userMailer)
        {
            _repository = repository;
            _userMailer = userMailer;
        }
        public void CreateNewUser(string name, string email, string password)
        {
            // Create the user's account
            _repository.Add(new User { Name = name, Email = email, Password = password });
            _repository.SaveChanges();
            // Now send a welcome email to the user
            _userMailer.Welcome(new WelcomeMailModel { Name = name, To = email }).Send();
        }
    }
