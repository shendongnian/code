    public class User{
    
    }
    
    public abstract class UserRepository{
        public abstract void InsertUser(User user);
    }
    
    public class SqlUserRepository : UserRepository{
        public override void InsertUser(User user)
        {
          //Do it
        }
    }
    
    public class FileSystemUserRepository : UserRepository{
        public override void InsertUser(User user)
        {
          //Do it
        }
    }
    
    public class UserService{
        private readonly UserRepository userRepository;
        
        public UserService(UserRepository userRepository){
            this.userRepository = userRepository;
        }
    
        public void InsertUser(User user){
            if(user == null) throw new ArgumentNullException("user");
            //other checks
            this.userRepository.InsertUser(user);
        }
    }
