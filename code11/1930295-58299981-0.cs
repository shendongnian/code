    public class CustomAuthorizationHandler : AuthorizationHandler<CustomAuthRequirement>
    {
        private readonly IServiceProvider _serviceProvider;
        public CustomAuthorizationHandler (IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       CustomAuthRequirement requirement)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<SomeDbContext>();
                //...
            }
        }
    }
