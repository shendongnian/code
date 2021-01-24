    // Pseudo-Code
    public class MyJob : IJob
    {
        private readonly IServiceLocator _serviceLocator;
        public MyJob(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }
        public async Task Execute(JobExecutionContext context)
        {
            using(_serviceLocator.BeginScope())
            {
                var worker = _serviceLocator.GetService<MyWorker>();
                await worker.DoWorkAsync();
            }
        }
    }
