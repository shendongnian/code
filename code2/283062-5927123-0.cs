    public interface IUser
    {
        string Name { get; }
        bool IsNew { get; }
    }
    
    public class User : IUser
    {
        public string Name { get; private set; }
        public bool IsNew { get; private set; }
    }
    
    public class UserService : IUserService
    {
        public void ValidateUser(IUser user)
        {
            var repository = RepositoryFactory.GetUserRepository(); // use IoC if needed
    
            if (user.IsNew && repository.UserExists(user.Name))
                throw new ValidationException("Username already exists");
        }
    }
