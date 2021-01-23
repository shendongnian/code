    public class MessageException : Exception
    {
        public MessageException(MessageCollection messages)
            : base("One or more messages were collected")
        {
            Messages = messages;
        }
        public MessageCollection Messages { get; private set; }
    }
