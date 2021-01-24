    public class UserService {
        private ICommonRepository<User> repository;
        public UserService(ICommonRepository<User> repository) {
            this.repository = repository;
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
