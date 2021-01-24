    public interface IMessage<T>
    {
        T content { get; }
        string sender { get; }
        DateTime sent { get; }
    }
