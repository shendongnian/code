    var instance = (IEncapsulatedMessageHandler)Activator.CreateInstance(typeof(Handler));
    instance.HandleMessage(new MyMessageType());
    public class Message { }
    public class MyMessageType : Message { }
    public interface IEncapsulatedMessageHandler
    {
        void HandleMessage(Message message);
    }
    public abstract class EncasulatedMessageHandler<T> : IEncapsulatedMessageHandler where T : Message
    {
        public abstract void HandleMessage(T message);
        void IEncapsulatedMessageHandler.HandleMessage(Message message)
        {
            var msg = message as T;
            if (msg != null)
                HandleMessage(msg);
        }
    }
    public class Handler : EncasulatedMessageHandler<MyMessageType>
    {
        public override void HandleMessage(MyMessageType message)
        {
            Console.WriteLine("Yo!");
        }
    }
