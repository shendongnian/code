    public class StartupEmailHostedService : IHostedService {
        private readonly IEmailSender emailSender;
        private readonly ILogger logger;
        private EmailStatus emailStatus;
        
        public StartupEmailHostedService(IEmailSender emailSender, EmailStatus emailStatus, ILogger<StartupEmailHostedService> logger) {
            this.services = services;
            this.logger = logger;
            this.emailStatus = emailStatus;
        }
        public async Task StartAsync(CancellationToken cancellationToken) {
            try {
                await emailSender.SendEmailAsync(Options.Support, "App STARTUP", $"email success.");
                emailStatus.failed = false;
            } catch (SmtpCommandException ex) {
                logger.LogError(ex.Message);
                emailStatus.failed = true;
            } catch (Exception ex) {
                logger.LogError(ex.Message);
                logger.LogError("Task Inner Exception: " + ex.InnerException);
                logger.LogError("Task StackTrace: " + ex.StackTrace);
                emailStatus.failed = true;
            };
        }
        public Task StopAsync(CancellationToken cancellationToken) {
            return Task.CompletedTask;
        }
    }
    
