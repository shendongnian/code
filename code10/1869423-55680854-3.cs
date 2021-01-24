    public class UserService {
        private IRepository<User> userRepository;
        public UserService(IRepository<User> userRepository) {
            this.userRepository = userRepository;
        }
        public bool DoesUserRecordExist(Guid userId) {
            var existingData = repository.DoesRecordExist(userId);
            if (existingData) {
                //do stuff
            } else {
                //do other stuff
            }
        }        
    }
