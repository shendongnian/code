    internal class SeedData
    {
        static AppDbContext _dataContext;
        internal static void Initialize(IServiceProvider serviceProvider)
        {
            _dataContext = (AppDbContext)serviceProvider.GetService(typeof(AppDbContext));
            var ensureCreated = _dataContext.Database.EnsureCreated();
            if (ensureCreated)
            {
                CreatePersonData();
                CreateGameData();
                CreateStudioData();
                try
                {
                    _dataContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        private static void CreatePersonData() { /* your code... */ }
        private static void CreateGameData() { /* your code... */ }
        private static void CreateStudioData() { /* your code... */ }
    }
