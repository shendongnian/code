    public interface IObserver
    {
        void SomeMethod();
    }
    public class Observer<T>: IObserver
    {
        public Observer(ObserverCallback<T> callback)
        {
        }
        public void SomeMethod()
        {
        }
    }
    var observerList = new List<IObserver>();
    observerList.Add(new Observer<Player>(ACallbackFunction));
    observerList.ForEach(o => o.SomeMethod());
