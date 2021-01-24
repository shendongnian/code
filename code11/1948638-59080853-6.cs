    public class Observer
    {
        public void SomeMethod();
    }
    public class Observer<T>
    {
        public Observer<ObserverCallback<T> callback)
        {
        }
    }
    var observerList = new List<Observer>();
    observerList.Add(new Observer<Player>(ACallbackFunction));
    observerList.ForEach(o => o.SomeMethod());
