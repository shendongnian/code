    public class Message<T>:IMessage<T>
    {
    	public T content { get; }
        public string sender { get; }
        public DateTime sent { get; }
    }
