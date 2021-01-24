    public interface IMessage { }
    
    public class TestMessage: IMessage { public string Test {get;set;} }
    
    public interface IMediator
    {
        void Subscribe(ISubscriber subscriber);
        void Send(IMessage message);
    }
    
    public interface ISubscriber { 
        void Notify(IMessage message);
    }
    
    public class ConcreteMediator : IMediator
    {
        private List<ISubscriber> _subscribers = new List<ISubscriber>();
    
        public void Subscribe(ISubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }
    
        public void Send(IMessage message)
        {
             var copy = new List<ISubscriber>(_subscribers);
             foreach(var sub in copy)
                sub.Notify(message);
        }
    }
