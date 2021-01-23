    class Disposer : IDisposable
    {
        private IDisposable target;
        public Disposer(IDisposable target)
        {
            this.target = target;
        }
        public void Cancel()
        {
            this.target = null;
        }
        public void Dispose()
        {
            this.target?.Dispose();
            Cancel();
        }
    }
