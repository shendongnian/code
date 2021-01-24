    public class MyRepo
    {
        private readonly IServiceProvider _serviceProvider;
        public MyRepo(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        ...
    }
