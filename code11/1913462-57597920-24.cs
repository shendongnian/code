    public class Message<T>
    {
        public Message(T content, Guid id, string messageType, DateTime consumeDate)
        {
            Content = content;
            Id = id;
            MessageType = messageType;
            ConsumeDate = consumeDate;
        }
        public T Content { get; }
        public Guid Id { get;  }
        public string MessageType { get; }
        public DateTime ConsumeDate { get;  }
    }
