    public interface IReminderJob : IJob
    {
    }
    public class ReminderJob : IReminderJob
    {
        ILogger<ReminderJob> _logger;
        IBot _bot;
        public ReminderJob(ILogger<ReminderJob> logger, IBot bot)
        {
            _logger = logger;
            _bot = bot;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            var parameters = context.JobDetail.JobDataMap;
            var userId = parameters.GetLongValue(ReminderJobConst.ChatId);
            var homeWorkId = parameters.GetLongValue(ReminderJobConst.HomeWordId);
            await _bot.Send(userId.ToString(), "test");
        }
    }
