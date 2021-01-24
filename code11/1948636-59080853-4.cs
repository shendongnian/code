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
