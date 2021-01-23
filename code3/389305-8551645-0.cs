    public class BlockingStack<T>
    {
        private Stack<T> _internalStack;
        private AutoResetEvent _blockUntilAvailable;
    
        public BlockingStack()
        {
            _internalStack = new Stack<T>(5);
            _blockUntilAvailable = new AutoResetEvent(false);
        }
    
        public T Pop()
        {
            lock (_internalStack)
            {
                if (_internalStack.Count == 0)
                    _blockUntilAvailable.WaitOne();
    
                return _internalStack.Pop();
            }
        }
    
        public void Push(T obj)
        {
            lock (_internalStack)
            {
                _internalStack.Push(obj);
                _blockUntilAvailable.Set();
            }
        }
    }
