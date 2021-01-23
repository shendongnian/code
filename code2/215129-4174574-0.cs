    public class MessageCollection : Collection<Message>
    {
    }
    public class Message
    {
        public Message(Severity severity, string message)
        {
            Severity = severity;
            Message = message;
        }
        public Severity Severity { get; private set; }
        public string Message { get; private set; }
    }
    public enum Severity
    {
        Error,
        Warning,
        Info
    }
