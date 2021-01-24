    public class Foo : IFoo
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
    
        public Foo(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
    
        public async Task Update(Order order)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<MyContext>();
                // this context is now separate from others
                // …
            }
        }
    }
