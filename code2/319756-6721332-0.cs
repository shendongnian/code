    public class MyClass<T> : IObservable<T>
    {
        private readonly IObservable<T> m_Source;
        public MyClass(IObservable<T> source)
        {
            if (source == null) throw new ArgumentNullException("source");
            m_Source = source.Do(OnNext, OnError, OnCompleted);
            OnInitialize();
        }
        public IDisposable Subscribe(IObserver<T> observer)
        {
            OnSubscribe();
            return m_Source.Subscribe(observer);
        }
        private void OnInitialize()
        {
            Console.WriteLine("OnInitialize");
        }
        private void OnSubscribe()
        {
            Console.WriteLine("OnSubscribe");
        }
        private void OnNext(T value)
        {
            Console.WriteLine("OnNext: {0}", value);
        }
        private void OnError(Exception error)
        {
            Console.WriteLine("OnError: {0}", error.Message);
        }
        private void OnCompleted()
        {
            Console.WriteLine("OnCompleted");
        }    
    }
