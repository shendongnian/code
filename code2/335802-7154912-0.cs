    public class CustomerMovedEventHandler
        : IEventHandler<CustomerMovedEvent>
    {
        public static int handleCount = 0;
        public void Handle(CustomerMovedEvent e) { handleCount++; }
    }
