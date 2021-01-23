    class Program
    {
        static IContainer container;
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .AssignableTo<IMessageHandler>()
                .Keyed<IMessageHandler>(t => GetMessageType(t));
            container = builder.Build();
            InvokeHandlers(MessageType.Type1);
            InvokeHandlers(MessageType.Type2);
            Console.ReadKey();
        }
        static MessageType GetMessageType(Type type)
        {
            var att = type.GetCustomAttributes(true).OfType<MessageHandlerAttribute>().FirstOrDefault();
            if (att == null)
            {
                throw new Exception("Somone forgot to put the MessageHandlerAttribute on an IMessageHandler!");
            }
            return att.MessageType;
        }
        static void InvokeHandlers(MessageType type)
        {
            using (var lifetime = container.BeginLifetimeScope())
            {
                // I'm impressed that Autofac knows what I mean here!
                var handlers = lifetime.ResolveKeyed<IEnumerable<IMessageHandler>>(type);
                foreach (var handler in handlers)
                {
                    handler.Handle();
                }
            }
        }
    }
    public enum MessageType
    {
        Type1,
        Type2,
    }
    public interface IMessageHandler
    {
        void Handle();
    }
    public class MessageHandlerAttribute : Attribute
    {
        public MessageHandlerAttribute(MessageType messageType)
        {
            MessageType = messageType;
        }
        public MessageType MessageType { get; private set; }
    }
    [MessageHandler(MessageType.Type1)]
    public class Handler1 : IMessageHandler
    {
        public void Handle()
        {
            Console.WriteLine("A handler for Type1");
        }
    }
    [MessageHandler(MessageType.Type1)]
    public class Handler2 : IMessageHandler
    {
        public void Handle()
        {
            Console.WriteLine("Another handler for Type1");
        }
    }
    [MessageHandler(MessageType.Type2)]
    public class Handler3 : IMessageHandler
    {
        public void Handle()
        {
            Console.WriteLine("A handler for Type2");
        }
    }
