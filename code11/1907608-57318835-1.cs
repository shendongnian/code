    interface IFoo
    {
        event Action Barred;
        void Bar();
    }
    class BasicFoo : IFoo
    {
        public event Action Barred;
        public void Bar() { … }
    }
    class DecoratedFoo : IFoo
    {
        public DecoratedFoo(IFoo foo = null) => this.Decorated = foo;
        public event Action Barred;
        public void Bar()
        {
            try {
                this._lock.Wait();
                this._decorated?.Bar();
            } finally {
                this._lock.Release();
            }
        }
        private SemaphoreSlim _lock = new SemaphoreSlim(1, 1);
        public IFoo Decorated {
            get {
                try {
                    this._lock.Wait();
                    return this._decorated;
                } finally {
                    this._lock.Release();
                }
            }
            set {
                try {
                    this._lock.Wait();
                    if (this._decorated != null) {
                        this._decorated.Barred -= this.OnDecoratedBarred;
                    }
                    this._decorated = value;
                    if (this._decorated != null) {
                        this._decorated.Barred += this.OnDecoratedBarred;
                    }
                } finally {
                    this._lock.Release();
                }
            }
        }
        private IFoo _decorated = null;
        private void OnDecoratedBarred()
        {
            try {
                this._lock.Wait();
                Action barred = this.Barred;
            } finally {
                this._lock.Release();
            }
            barred?.Invoke();
        }
    }
