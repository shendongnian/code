    public class CountingSubject<T>
    {
        private ISubject<T> internalSubject;
        private int subscriberCount;
        public CountingSubject()
            : this(new Subject<T>())
        {
        }
        public CountingSubject(ISubject<T> internalSubject)
        {
            this.internalSubject = internalSubject;
        }
        public IDisposable Subscribe(IObserver<T> observer)
        {
            Interlocked.Increment(ref subscriberCount);
            return new CompositeDisposable(
                this.internalSubject.Subscribe(observer),
                Disposable.Create(() => Interlocked.Decrement(ref subscriberCount))
            });
        }
        public int SubscriberCount
        {
            get { return subscriberCount; }
        }
    }
