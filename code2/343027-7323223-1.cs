    using System.Reactive.Linq;
    static class WeakObservation
    {
        public static IObservable<T> ToWeakObservable<T>(this IObservable<T> observable)
        {
            return Observable.Create<T>(observer =>
                (IDisposable)new DisposableReference(new WeakObserver<T>(observable, observer), observer)
                );
        }
    }
    class DisposableReference : IDisposable
    {
        public DisposableReference(IDisposable InnerDisposable, object Reference)
        {
            this.InnerDisposable = InnerDisposable;
            this.Reference = Reference;
        }
        private IDisposable InnerDisposable;
        private object Reference;
        public void Dispose()
        {
            InnerDisposable.Dispose();
        }
    }
    class WeakObserver<T> : IObserver<T>, IDisposable
    {
        private readonly WeakReference reference;
        private readonly IDisposable subscription;
        private bool disposed;
        public WeakObserver(IObservable<T> observable, IObserver<T> observer)
        {
            this.reference = new WeakReference(observer);
            this.subscription = observable.Subscribe(this);
        }
        public void OnCompleted()
        {
            var observer = (IObserver<T>)this.reference.Target;
            if (observer != null) observer.OnCompleted();
            else this.Dispose();
        }
        public void OnError(Exception error)
        {
            var observer = (IObserver<T>)this.reference.Target;
            if (observer != null) observer.OnError(error);
            else this.Dispose();
        }
        public void OnNext(T value)
        {
            var observer = (IObserver<T>)this.reference.Target;
            if (observer != null) observer.OnNext(value);
            else this.Dispose();
        }
        public void Dispose()
        {
            if (!this.disposed)
            {
                this.disposed = true;
                this.subscription.Dispose();
            }
        }
    }
