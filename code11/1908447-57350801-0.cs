    public class DataAccess {
        private IDbContext _dbContext;
        public DataAccess(IDbContext context) {
            _dbContext = context;
        }
        // atomic example
        public UserModel GetUser(int id) {
            return _dbContext.UserTable
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }
        // not-atomic example
        public bool RecordUserActivity(UserModel user, IEnumerable<UserActivity> activities) {
            try {
                _dbContext.BeginTransaction();
                
                // messy example
                _dbContext.UserLogins
                    .Add(activities.Where(x => x.ActivityType == ActivityTypes.Logins));
                _dbContext.UserEdits
                    .Add(activities.Where(x => x.ActivityType == ActivityTypes.Edits));
                // 
                _dbContext.CommitTransaction();
                return true;
            } catch (Exception ex) {
                // log your exceptions!
                _dbContext.RollbackTransaction();
            }
            return false;
        }
    }
