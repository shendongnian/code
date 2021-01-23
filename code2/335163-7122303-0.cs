    public interface IAudit<T> {
        DateTime DateCreated { get; set; }
    }
    public class UserAudit : IAudit<User> {
        public string UserName { get; set; }
        public DateTime DateCreated { get; set; }
    
        public UserAdit(User user) {
            UserName = user.UserName;
        }
    }
