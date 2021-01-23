    class ServiceProxy : IAmAService
    {
        private readonly object locker = new object();
        private readonly Func<IAmAService> factory;
        private IAmAService instance;
        public ServiceProxy(Func<IAmAService> factory)
        {
            this.factory = factory;
        }
        void IAmAService.DoSomething()
        {
            this.GetInstance().DoSomething();
        }
        private IAmAService GetInstance()
        {
            // Double-checked lock.
            if (this.instance == null)
            {
                lock (this.locker)
                {
                    if (this.instance == null)
                    {
                        this.instance = this.factory();
                    }
                }
            }
            return this.instance;
        }
    }
