    public class A
    {
        private Action _delegate;
        private AutoResetEvent _asyncActiveEvent;
    
        public IAsyncResult BeginExecute(AsyncCallback callback, object state)
        {
            _delegate = () => Execute();
            if (_asyncActiveEvent == null)
            {
                bool flag = false;
                try
                {
                    Monitor.Enter(this, ref flag);
                    if (_asyncActiveEvent == null)
                    {
                        _asyncActiveEvent = new AutoResetEvent(true);
                    }
                }
                finally
                {
                    if (flag)
                    {
                        Monitor.Exit(this);
                    }
                }
            }
            _asyncActiveEvent.WaitOne();
            return _delegate.BeginInvoke(callback, state);
        }
    
        public void EndExecute(IAsyncResult result)
        {
            try
            {
                _delegate.EndInvoke(result);
            }
            finally
            {
                _delegate = null;
                _asyncActiveEvent.Set();
            }
        }
    
        private void Execute()
        {
            Thread.Sleep(1000 * 3);
        }
    }
    
    class Program
    {
        static void Main()
        {
            A a = new A();
            a.BeginExecute(state =>
            {
                Console.WriteLine("finished");
                ((A)state.AsyncState).EndExecute(state);
            }, a);
            Console.ReadLine();
        }
    }
