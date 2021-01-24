    class MyClass
    {
        private ConcurrentQueue<string> changes;
        public MyClass(INotifyPropertyChanged observable)
        {
            observable.PropertyChanged += this.Handler;
            // Another thread changes a property at this point
            this.changes = new ConcurrentQueue<string>();
        }
        private void Handler(object sender, PropertyChangedEventArgs e)
        {
            this.changes?.Enqueue(e.PropertyName);
            // Nothing breaks, the change is simply not recorded
        }
    }
