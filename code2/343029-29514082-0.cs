    public class WeakObservable<T>: IObservable<T>
    {
        private IObservable<T> _source;
        public WeakObservable(IObservable<T> source)
        {
            #region Validation
            if (source == null)
                throw new ArgumentNullException("source");
            #endregion Validation
            _source = source;
        }
        public IDisposable Subscribe(IObserver<T> observer)
        {
            IObservable<T> source = _source;
            if(source == null)
                return Disposable.Empty;
            var weakObserver = new WaekObserver<T>(observer);
            IDisposable disp = source.Subscribe(weakObserver);
            return disp;
        }
    }
        public class WaekObserver<T>: IObserver<T>
    {
        private WeakReference<IObserver<T>> _target;
        public WaekObserver(IObserver<T> target)
        {
            #region Validation
            if (target == null)
                throw new ArgumentNullException("target");
            #endregion Validation
            _target = new WeakReference<IObserver<T>>(target);
        }
        private IObserver<T> Target
        {
            get
            {
                IObserver<T> target;
                if(_target.TryGetTarget(out target))
                    return target;
                return null;
            }
        }
        #region IObserver<T> Members
        /// <summary>
        /// Notifies the observer that the provider has finished sending push-based notifications.
        /// </summary>
        public void OnCompleted()
        {
            IObserver<T> target = Target;
            if (target == null)
                return;
            target.OnCompleted();
        }
        /// <summary>
        /// Notifies the observer that the provider has experienced an error condition.
        /// </summary>
        /// <param name="error">An object that provides additional information about the error.</param>
        public void OnError(Exception error)
        {
            IObserver<T> target = Target;
            if (target == null)
                return;
            target.OnError(error);
        }
        /// <summary>
        /// Provides the observer with new data.
        /// </summary>
        /// <param name="value">The current notification information.</param>
        public void OnNext(T value)
        {
            IObserver<T> target = Target;
            if (target == null)
                return;
            target.OnNext(value);
        }
        #endregion IObserver<T> Members
    }
        public static class RxExtensions
    {
        public static IObservable<T> ToWeakObservable<T>(this IObservable<T> source)
        {
            return new WeakObservable<T>(source);
        }
    }
            static void Main(string[] args)
        {
            Console.WriteLine("Start");
            var xs = Observable.Interval(TimeSpan.FromSeconds(1));
            Sbscribe(xs);
            Thread.Sleep(2020);
            Console.WriteLine("Collect");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            Console.WriteLine("Done");
            Console.ReadKey();
        }
        private static void Sbscribe<T>(IObservable<T> source)
        {
            source.ToWeakObservable().Subscribe(v => Console.WriteLine(v));
        }
