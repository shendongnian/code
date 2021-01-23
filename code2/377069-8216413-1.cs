    using System.Reactive.Subjects;
    using System.Reactive.Linq;
    public class Pooler 
        : IObservable<HappenedEventArgs>, 
          IDisposable
    {
        void Dispose()
        {
            if (_pool != null) _pool.Dispose();
            if (_sourceSubs != null)
            {
                foreach (var d in _sourceSubs.Values)
                {
                    d.Dispose();
                }
                _sourceSubs.Clear();
            }
        }
        private Subject<HappenedEventArgs> _pool = new Subject<HappenedEventArgs>();
        private Dictionary<IEventSource, IDisposable> _sourceSubs = new Dictionary<IEventSource, IDisposable>();
        public IDisposable Subscribe(IObserver<HappenedEventArgs> observer)
        {
            return _pool.Subscribe(observer);
        }
        public void Register(IEventSource item)
        {
            if (_sourceSubs.ContainsKey(item))
            {
                return; //already registered
            }
            else
            {
                _sourceSubs.Add(item,
                                Observable.FromEventPattern((EventHandler<HappenedEventArgs> h) => item.Happened += h,
                                                            h => item.Happened -= h)
                                          .Select(ep => ep.EventArgs)
                                          .Subscribe(_pool));
            }
        }
        internal void Unregister(IEventSource item)
        {
            IDisposable disp = null;
            if (_sourceSubs.TryGetValue(item, out disp))
            {
                _sourceSubs.Remove(item);
                disp.Dispose();
            }
        }
    }
