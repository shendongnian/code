    public sealed class WorkingClass : IDisposable
    {
        private BlockingCollection<int> _collection = new BlockingCollection<int>(1);
        private List<Task> _consumerTasks = new List<Task>();
            
        public WorkingClass(IObservable<int> rawValues)
        {
            rawValues.Subscribe(x => _collection.Add(x));
        }
        public IObservable<int> ProcessedValues()
        {
            return Observable.Create<int>(observer =>
            {
                _consumerTasks.Add(Task.Factory.StartNew(() => Consume(observer), TaskCreationOptions.LongRunning));
                return Disposable.Empty;
            });
        }
        private void Consume(IObserver<int> observer)
        {
            try
            {
                foreach (int value in _collection.GetConsumingEnumerable())
                {
                    Thread.Sleep(1000); //Simulate long work
                    observer.OnNext(value * 2);
                }
            }
            catch (Exception ex)
            {
                observer.OnError(ex);
            }
        }
        public void Dispose()
        {
            _collection.CompleteAdding();
            Task.WaitAll(_consumerTasks.ToArray());
            _collection.Dispose();
        }
    }
