    public class UserInfoRetriever : IUserInfoRetriever
    {
        private Task<Dictionary<Guid, UserInfo>> _cacheTask;
        private readonly object _locker = new object();
        public UserInfo GetUserInfo(Guid userId)
        {
            lock (_locker)
            {
                if (_cacheTask == null || _cacheTask.IsFaulted)
                {
                    _cacheTask = GetAllUserInfoAsync();
                }
            }
            return _cacheTask.Result.TryGetValue(userId, out var v) ? v : null;
        }
        private async Task<Dictionary<Guid, UserInfo>> GetAllUserInfoAsync()
        {
            var dictionary = new Dictionary<Guid, UserInfo>();
            // Fetch data asynchronously and fill the dictionary
            return dictionary;
        }
    }
