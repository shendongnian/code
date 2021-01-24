    public interface IEmail
    {
        void Send(Message message);
    }
    public class Message
    {
        public string To { get; set; }
        public string Body { get; set; }
    }
