    public class HelloJob : IJob
    {
        private readonly MessageSender _messageSender;
        public HelloJob(MessageSender messageSender)
        {
            _messageSender = messageSender;
        }
    }
