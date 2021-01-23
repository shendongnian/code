    public class ClassThatSendsMessages
    {
        private readonly IBus _bus;
        public static Action<IMyMessage> BuildMessage { private get; set; }
        public ClassThatSendsMessages(IBus bus /*, ... */)
        {
            _bus = bus;
            /* ... */
        }
        public void CodeThatSendsMessage()
        {
            /* ... */
            _bus.Send<IMyMessage>(mm => BuildMessage (mm));
            /* ... */
        }
    }
