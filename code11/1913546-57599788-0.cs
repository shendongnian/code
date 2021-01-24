    public class Message<TContent>
    {
        public Message(TContent content, Guid id, DateTime received)
        {
            Content = content;
            Id = id;
            Received = received;
        }
        public TContent Content { get; }
        public Guid Id { get; }
        public DateTime Received { get; }
    }
