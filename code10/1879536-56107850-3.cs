    public sealed EmailJob {
      public EmailJob(string recipientAddress, int emailTemplateId, ..){
        // ..
      }
    
      // ..
    }
    
    public interface IEmailJobQueue
    {
        Task EnqueueJobAsync(EmailJob job);
        Task<EmailJob> DequeueJobAsync(CancellationToken cancellationToken);
    }
    
    public class InMemoryEmailJobQueue : IEmailJobQueue
    {
        private ConcurrentQueue<EmailJob> _jobs = new ConcurrentQueue<EmailJob>();
    
        public Task EnqueueJobAsync(EmailJob job)
        {
            if (job == null)
            {
                throw new ArgumentNullException(nameof(workItem));
            }
    
            _jobs.Enqueue(job);
    
            return Task.Completed;
        }
    
        public Task<EmailJob> DequeueJobAsync(CancellationToken cancellationToken)
        {
            if (!_jobs.TryDequeue(out var job){
              return Task.FromResult<EmailJob>(null);
            }
    
            return Task.FromResult(job);
        }
    }
    
    public class EmailSenderService : BackgroundService
    {
        private readonly ILogger _logger;
    
        public EmailSenderService(IEmailJobQueue emailJobQueue, ILoggerFactory loggerFactory)
        {
            _emailJobQueue = emailJobQueue;
            _logger = loggerFactory.CreateLogger<QueuedHostedService>();
        }
    
        public IEmailJobQueue _emailJobQueue { get; }
    
        protected async override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var job = await _emailJobQueue.DequeueAsync(cancellationToken);
    
                if (job == null) {
                  Task.Delay(512);
                  continue;
                }
    
                try
                {
                    // .. sending email based on data from 'job'
                    // Don't forget to handle case when sending fails - either use [Polly.RetryPolicy] (https://github.com/App-vNext/Polly#retry) or persist failed job to postponed processing.
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error occurred executing {nameof(job)}.");
                }
            }
        }
    }
