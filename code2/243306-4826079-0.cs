    public class SomeObservable<T> : IObservable<T>
    {
            private Subject<T> subject = new Subject<T>();
            public IDisposable Subscribe(IObserver<T> observer)
            {
                return subject.Subscribe(observer);
            }
    }
