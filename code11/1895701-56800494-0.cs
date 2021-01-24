    public class ChatHub : Hub
    {      
        private IServiceProvider _serviceProvider;
        public ChatHub(IServiceProvider serviceProvider)
        {
            _serviceProvider= serviceProvider;
        }
        public async Task Foo()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
               var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
               var user = scope.ServiceProvider.GetRequiredService<IUser>();    
          
            }
        }
    }
