    public class SmartObservableCollection<T> : ObservableCollection<T>
    {
        [DebuggerStepThrough]
        public SmartObservableCollection(Action<Action> dispatchingAction = null)
            : base()
        {
            iSuspendCollectionChangeNotification = false;
            if (dispatchingAction != null)
                iDispatchingAction = dispatchingAction;
            else
                iDispatchingAction = a => a();
        }
        private bool iSuspendCollectionChangeNotification;
        private Action<Action> iDispatchingAction;
    
        [DebuggerStepThrough]
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (!iSuspendCollectionChangeNotification)
            {
                using (IDisposable disposeable = this.BlockReentrancy())
                {
                    iDispatchingAction(() =>
                    {
                        base.OnCollectionChanged(e);
                    });
                }
            }
        }
        [DebuggerStepThrough]
        public void SuspendCollectionChangeNotification()
        {
            iSuspendCollectionChangeNotification = true;
        }
        [DebuggerStepThrough]
        public void ResumeCollectionChangeNotification()
        {
            iSuspendCollectionChangeNotification = false;
        }
    
    
        [DebuggerStepThrough]
        public void AddRange(IEnumerable<T> items)
        {
            this.SuspendCollectionChangeNotification();
            try
            {
                foreach (var i in items)
                {
                    base.InsertItem(base.Count, i);
                }
            }
            finally
            {
                this.ResumeCollectionChangeNotification();
                var arg = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
                this.OnCollectionChanged(arg);
            }
        }
    
    
    }
