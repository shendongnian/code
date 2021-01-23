    public static class ObservableApmExtensions
    {
        public static IObservable<byte> ToObservable(this FileStream source)
        {
            return source.ToObservable(4096, Scheduler.CurrentThread);
        }
    
        public static IObservable<byte> ToObservable(this FileStream source, int buffersize, IScheduler scheduler)
        {
            return Observable.Create<byte>(o =>
            {
                var initialState = new StreamReaderState(source, buffersize);
                var subscription = new MultipleAssignmentDisposable();
                Action<StreamReaderState, Action<StreamReaderState>> action =
                    (state, self) =>
                    {
                        subscription.Disposable = state.ReadNext()
                            .Subscribe(
                                bytesRead =>
                                {
                                    for (int i = 0; i < bytesRead; i++)
                                    {
                                        o.OnNext(state.Buffer[i]);
                                    }
                                    if (bytesRead > 0)
                                        self(state);
                                    else
                                        o.OnCompleted();
                                },
                                o.OnError);
                    };
    
                var scheduledAction = scheduler.Schedule(initialState, action);
                return new CompositeDisposable(scheduledAction, subscription);
            });
        }
    
        private sealed class StreamReaderState
        {
            private readonly int _bufferSize;
            private readonly Func<byte[], int, int, IObservable<int>> _factory;
    
            public StreamReaderState(Stream source, int bufferSize)
            {
                _bufferSize = bufferSize;
                _factory = Observable.FromAsyncPattern<byte[], int, int, int>(source.BeginRead, source.EndRead);
                Buffer = new byte[bufferSize];
            }
    
            public IObservable<int> ReadNext()
            {
                return _factory(Buffer, 0, _bufferSize);
            }
    
            public byte[] Buffer { get; set; }
        }
    }
