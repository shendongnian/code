    public class MyObserver : IObserver<string>, IObservable<string>
    {
        Subject<string> s = new Subject<string>();
        public MyObserver(IObserver<string> obs)
        {
            s.Subscribe(obs);
        }
        public void OnCompleted()
        { }
        public void OnError(Exception error)
        { }
        public void OnNext(string value)
        {
            //If condition matches then else dont do on next
            s.OnNext(value);
        }
        public IDisposable Subscribe(IObserver<string> observer)
        {
            return s.Subscribe(observer);
        }
    }
    public class LastObserver : IObserver<string>
    {
        public void OnCompleted()
        {   }
    
        public void OnError(Exception error)
        { }
    
        public void OnNext(string value)
        { //Do something with not catched value
        }
    }
    static LastObserver obs = new LastObserver();
    static void Main()
    {
        var timer = Observable.Interval(TimeSpan.FromSeconds(1)).Select(i => i.ToString());
        timer.Subscribe(new MyObserver(obs));
        timer.Subscribe(new MyObserver(obs));
        timer.Subscribe(new MyObserver(obs));
                
    } 
