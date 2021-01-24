    public class MyService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
    
        public static async Task<MyService> BuildMyService(IServiceScopeFactory serviceScopeFactory)
        {
            await DoSomething();
            return new MyService(serviceScopeFactory);
        }
        
        public MyService(IServiceScopeFactory serviceScopeFactory)
        {
            this._serviceScopeFactory = serviceScopeFactory;
        }
    }
