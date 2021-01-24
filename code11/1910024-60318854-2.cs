    public class UserStore :  IUserStore<User>, IUserEmailStore<User>, IUserPasswordStore<User>, IUserRoleStore<User> IUserLockoutStore<User>
    {
        #region Other Interface Implementation
        #endregion
        #region  IUserLockoutStore
        public Task<DateTimeOffset?> GetLockoutEndDateAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            //Get user from Database and Set User LockoutEnd Date
            User user = FromDatabase(user.Id);
            return Task.FromResult(user.LockoutEnd);
        }
        public Task SetLockoutEndDateAsync(User user, DateTimeOffset? lockoutEnd, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            user.LockoutEnd = lockoutEnd;
            return Task.FromResult(0);
        }
        public Task<int> IncrementAccessFailedCountAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            user.AccessFailedCount += 1;
            return Task.FromResult(user.AccessFailedCount);
        }
        public Task ResetAccessFailedCountAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            user.AccessFailedCount = 0;
            return Task.FromResult(0);
        }
        public Task<int> GetAccessFailedCountAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            //Get user from database and assign accessFailedCount
              User user = FromDatabase(user.Id);
            return Task.FromResult(user.accessFailedCount);
        }
        public Task<bool> GetLockoutEnabledAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            //Get user from database and assign isLockOutEnabled
            User user = FromDatabase(user.Id);
            return Task.FromResult(user.isLockOutEnabled);
        }
        public Task SetLockoutEnabledAsync(User user, bool enabled, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            user.LockoutEnabled = enabled;
            return Task.FromResult(0);
        }
        #endregion 
        public User FromDataBase(string Id)
        {
            //Code to retrieve User from Database
        }
    }
