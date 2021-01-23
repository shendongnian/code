    public static IObservable<Tuple<string,IEnumerable<Tuple<string, int, object>>> 
        FromCustomCallbackPattern(ISomeCallbackPublisher publisher)
    {
        return Observable.CreateWithDisposable<T>(observer =>
        {
            var subject = new Subject<
                Tuple<string,IEnumerable<Tuple<string, int, object>>>();
    
            var callback = new ObservableSomeCallback(subject);
    
            Guid subscription = publisher.SubscribeToChanges(callback);
    
            return new CompositeDisposable(
                subject.Subscribe(observer),
                Disposable.Create(() => publisher.UnsubscribeFromChanges(subscription))
            );
        });
    }
    
    private class ObservableSomeCallback : ISomeCallbackInterface
    {
        private IObserver<Tuple<string,IEnumerable<Tuple<string, int, object>>> observer;
    
        public ObservableSomeCallback(
            IObserver<Tuple<string,IEnumerable<Tuple<string, int, object>>> observer)
        {
            this.observer = observer;
        }
    
        public void CallbackMethod(string id, IEnumerable<Tuple<string, int, object>> data)
        {
            this.observer.OnNext(new Tuple<
                string,IEnumerable<Tuple<string, int, object>>(id, data));
        }
    }
