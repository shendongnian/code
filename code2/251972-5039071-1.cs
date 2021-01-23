    public class MessageBus
    {
        public void Subscriber(ISubscriber subsriber)
        {
             // register your subscriber in some list
        }
        public void Publish(Message message)
        {
             // loop through subscribers and let them know
             // e.g. subscriber.Handle(message);
        }
    }
