    class DisposableEnumerable : IDisposable
    {
        private IEnumerable<IDisposable> items;
        public event UnhandledExceptionEventHandler DisposalFailed;
        public DisposableEnumerable(IEnumerable<IDisposable> items) => this.items = items;
        public void Dispose()
        {
            foreach (var item in items)
            {
                try
                {
                    item.Dispose();
                }
                catch (Exception e)
                {
                    var tmp = DisposalFailed;
                    tmp?.Invoke(this, new UnhandledExceptionEventArgs(e, false));
                }
            }
        }
    }
