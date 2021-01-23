    // Definition
    public interface IProfileFactory
    {
        IProfile CreateProfileForUser(string username);
    }
    // Usage
    var profile = Container.Resolve<IProfileFactory>()
        .CreateProfileForUser("John");
    // Registration
    Container.RegisterType<IProfileFactory, ProfileFactory>();
    // Mock implementation
    public class ProfileFactory : IProfileFactory
    {
        public IProfile CreateProfileForUser(string username)
        {
            IUser user = Container.Resolve<IUserManager>()
                .GetUser(username);
            return new UserProfile(user);
        }
    }
