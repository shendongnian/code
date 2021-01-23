    public interface IUserProxy
    {
        string FullName { get; }
    }
    public class UserProxyImpl : IUserProxy
    {
        public User User { get; set; }
        public string FullName
        {
            get { return User.FirstName + " " + User.LastName; }
        }
    }
