    public class EmailQueueService : IEmailQueueService {
        private readonly IAmazonSQS sqsClient 
        private readonly ILogger logger;
        public EmailQueueService(IAmazonSQS sqsClient, ILogger<EmailQueueService> logger) {
            this.sqsClient = sqsClient;
            this.logger = logger;
        }
        public async Task<bool> AddAsync(ContactFormModel contactForm) {
            
            var sendRequest = //...removed for clarity
            var response = await sqsClient.SendMessageAsync(sendRequest);
            return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
        }
    }
    
