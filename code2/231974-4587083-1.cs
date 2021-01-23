        public static IObservable<T> ObserveOnDispatcher<T>(this IObservable<T> observable, DispatcherPriority priority)
        {
            if (observable == null)
                throw new NullReferenceException();
            return observable.ObserveOn(Dispatcher.CurrentDispatcher, priority);
        }
        public static IObservable<T> ObserveOn<T>(this IObservable<T> observable, Dispatcher dispatcher, DispatcherPriority priority)
        {
            if (observable == null)
                throw new NullReferenceException();
            if (dispatcher == null)
                throw new ArgumentNullException("dispatcher");
            return Observable.CreateWithDisposable<T>(o =>
            {
                return observable.Subscribe(
                    obj => dispatcher.Invoke((Action)(() => o.OnNext(obj)), priority),
                    ex => dispatcher.Invoke((Action)(() => o.OnError(ex)), priority),
                    () => dispatcher.Invoke((Action)(() => o.OnCompleted()), priority));
            });
        }
