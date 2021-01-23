    // Message marker interface
    interface IMessage {}
    // Message handler interface
    interface IHandles<T> where T: IMessage
    {
        void Handle(T message);
    }
    // A message which defines mooing
    class MooMessage : IMessage {}
    
    // A message which defines woofing
    class WoofMessage : IMessage {}
    // A handler for moo messages
    class MooHandler : IHandles<MooMessage>
    {
        public void Handle(MooMessage message)
        {
            Console.WriteLine("moo");
        }
    }
    // A handler for woof messages
    class WoofHandler : IHandles<WoofMessage>
    {
        public void Handle(WoofMessage message)
        {
            Console.WriteLine("woof");
        }
    }
    class Program
    {
        // Generate some test messages
        static IEnumerable<IMessage> MessageGenerator()
        {
            yield return new WoofMessage();
            yield return new MooMessage();
        }
        static void Main(string[] args)
        {
            // configure container
            var builder = new ContainerBuilder();
            // Register message handlers here through configuration or convention...
            builder.RegisterType<WoofHandler>().AsImplementedInterfaces();
            builder.RegisterType<MooHandler>().AsImplementedInterfaces();
            var container = builder.Build();
            // handle all messages until done
            foreach (var message in MessageGenerator())
            {
                // resolve the handler for the message from the container
                var handler = container
                    .Resolve(typeof(IHandles<>)
                    .MakeGenericType(message.GetType()));
                // call the handler - you have to do this using reflection unfortunately
                // due to the nature of open generics.
                handler
                    .GetType()
                    .GetMethod("Handle")
                    .Invoke(handler, new object[] { message });
            }
        }
    }
