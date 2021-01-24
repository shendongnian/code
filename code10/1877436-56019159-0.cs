    public class MqSubscriptionBody
    {
        public int SubscriberID { get; set; }
        public string Topic { get; set; }
        public string Protocol { get; set; }
        public string ResponseContentType { get; set; }
        public MQ MQ { get; set; }
    }
    
    public class MQ
    {
        public string DestinationQueue { get; set; }
    }
