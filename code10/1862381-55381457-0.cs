    public class ExampleSingletonService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public ExampleSingletonService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        public async Task DoSomethingAsync()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetService<MyDbContext>();
                db.Add(new Foo());
                await db.SaveChangesAsync();
            }
        }
    }
