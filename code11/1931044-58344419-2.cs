    class LazyInitializer
    {
        private readonly Action initFunc;
        class State { public bool Initialized = false; }
        public LazyInitializer(Action initFunc)
        {
            this.initFunc = initFunc;
        }
        public Action CreateInitializer()
        {
            var state = new State();
            return () =>
            {
                lock (state)
                {
                    if (state.Initialized == false)
                    {
                        initFunc();
                        state.Initialized = true;
                    }
                }
            };
        }
    }
