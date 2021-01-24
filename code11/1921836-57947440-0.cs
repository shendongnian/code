    public class UserState
    {
        private readonly IServiceProvider _provider;
        public UserState(IServiceProvider provider)
        {
            _provider = provider;
        }
        public async Task DoWorkAsync()
        {
            using (var scope = _provider.CreateScope())
            using (var ctx = scope.ServiceProvider.GetService<MyDbContext>())
            {
                // do work
                await ctx.SaveChangesAsync();
            }
        }
    }
