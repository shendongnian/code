    public class Foo<T> //TODO come up with good name
    {
        private Func<Task<T>> factory;
        private Task<T> currentInvocation;
        private object key = new object();
        public Foo(Func<Task<T>> factory)
        {
            this.factory = factory;
        }
        public Task<T> Value
        {
            get
            {
                lock (key)
                {
                    if (currentInvocation == null)
                    {
                        currentInvocation = factory();
                        currentInvocation?.ContinueWith(_ =>
                        {
                            lock (key) { currentInvocation = null; }
                        });
                    }
                    return currentInvocation;
                }
            }
        }
    }
