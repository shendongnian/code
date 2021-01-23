    public class Semaphore
    {
        private int _count;
        private int _maximum;
        private object _countGuard;
        
        public Semaphore(int maximum)
        {
            _count = 0;
            _maximum = maximum;
            _countGuard = new object();
        }
        
        public void WaitOne()
        {
            while (true)
            {
                lock (_countGuard)
                {
                    if (_count < _maximum)
                    {
                        _count++;
                        return;
                    }
                }
                Thread.Sleep(50);
            }
        }
        
        public void ReleaseOne()
        {
            lock (_countGuard)
            {
                if (_count > 0)
                {
                    _count--;
                }
            }
        }
    }
    public class BlockingStack
    {
        private Stack<MyType> _internalStack;
        private Semaphore _blockUntilAvailable;
        public BlockingStack()
        {
            _internalStack = new Stack<MyType>(5);
            _blockUntilAvailable = new Semaphore(5);
            for (int i = 0; i < 5; ++i)
            {
                var obj = new MyType();
                Add(obj);
            }
        }
        public MyType Get()
        {
            _blockUntilAvailable.WaitOne();
            lock (_internalStack)
            {
                var obj = _internalStack.Pop();
                return obj;
            }
        }
        public void Add(MyType obj)
        {
            lock (_internalStack)
            {
                _internalStack.Push(obj);
                _blockUntilAvailable.ReleaseOne();
            }
        }
    }
