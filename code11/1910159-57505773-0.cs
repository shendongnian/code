    internal class TestJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Job started");
            return Task.CompletedTask;
        }
    }
