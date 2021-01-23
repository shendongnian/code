    public class StreamingSubscriber
    {
        private readonly ILogic _logic;
    
        public StreamingSubscriber(ILogicFactory logicFactory)
        {            
            _logic = logicFactory.Create(this);
        }
    
        public void OnNotificationEvent(object sender, NotificationEventArgs args)
        {
            // Do something with _logic
            var email = _logic.FetchEmail(args);
            // consume the email (omitted for brevity)
        }
    }
    public class ExchangeLogic : ILogic
    {   
        private readonly StreamingSubscriber _StreamingSubscriber;
        public ExchangeLogic (StreamingSubscriber subscriber){
           _StreamingSubscriber = streamingSubscriber;
           Subscribe();
        }
    
        private void Subscribe()
        {
            // Here is where I use StreamingSubscriber
            streamingConnection.OnNotificationEvent += _StreamingSubscriber.OnNotificationEvent;
        }
    
        public IEmail FetchEmail(NotificationEventArgs notificationEventArgs)
        {
            // Fetch email from Exchange
        }
    }
