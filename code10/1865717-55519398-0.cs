    public class SimpleSingleton
    {
        private SimpleSingleton() { }
        private static SimpleSingleton _instance;
        public static SimpleSingleton Instance => _instance ?? (_instance = new SimpleSingleton());
        public async Task<int> GetRefreshedValue()
        {
            return await GetRefreshedValueImplementation();
        }
        private volatile Task<int> _getRefreshedValueImplementationTask;
        private Task<int> GetRefreshedValueImplementation()
        {
            if (_getRefreshedValueImplementationTask is null || _getRefreshedValueImplementationTask.IsCompleted)
            {
                return _getRefreshedValueImplementationTask = Task.Run(async () =>
                {
                    int r = new Random().Next(1000, 2001);
                    await Task.Delay(r);
                    return r;
                });
            }
            return _getRefreshedValueImplementationTask;
        }
    }
