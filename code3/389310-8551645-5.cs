    public class BlockingStack<T>
    {
        private Stack<T> _internalStack;
    
        public BlockingStack()
        {
            _internalStack = new Stack<T>(5);
        }
    
        public T Pop()
        {
            lock (_internalStack)
            {
                if (_internalStack.Count == 0)
                    Monitor.Wait(_internalStack);
    
                return _internalStack.Pop();
            }
        }
    
        public void Push(T obj)
        {
            lock (_internalStack)
            {
                _internalStack.Push(obj);
                Monitor.Pulse(_internalStack);
            }
        }
    }
