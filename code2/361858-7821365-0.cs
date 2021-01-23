    public class ValueWatcher<TValue> : IDisposable
    {
        ManualResetEvent _ev = new ManualResetEvent(false);
        Func<TValue, bool> _isValueAcceptableFunc;
        public ValueWatcher(Func<TValue> CurrentValueFunc, Func<TValue, bool> IsValueAcceptableFunc)
        {
            _isValueAcceptableFunc = IsValueAcceptableFunc;
            ValueUpdated(CurrentValueFunc.Invoke());
        }
        public void ValueUpdated(TValue Value)
        {
            if (_isValueAcceptableFunc.Invoke(Value))
                _ev.Set();
            else
                _ev.Reset();
        }
        public bool Wait()
        {
            return _ev.WaitOne();
        }
        public bool Wait(int TimeoutMs)
        {
            return _ev.WaitOne(TimeoutMs);
        }
        public bool Wait(TimeSpan ts)
        {
            return _ev.WaitOne(ts);
        }
        #region IDisposable Members
        public void Dispose()
        {
            Dispose(true);
        }
        void Dispose(bool Disposing)
        {
            if (Disposing)
            {
                _ev.Dispose();
            }
        }
        #endregion
    }
