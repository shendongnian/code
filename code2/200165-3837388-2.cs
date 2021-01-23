    public class Observer : IObserver
    {
        public Observer(Publisher pub)
        {
            pub.Observers.Add(this);
        }
        
        void IObserver.SomethingHappened()
        {
        }
    }
    
    public class Publisher
    {
        public List<IObserver> Observers { get; private set; }
    }
    public interface IObserver
    {
        void SomethingHappened();
    }
