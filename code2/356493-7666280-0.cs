    public class CustomCollectionInherited : ObservableCollection<object>
    {
        private Dictionary<Type, UInt32> _count = new Dictionary<Type, uint>();
        public UInt32 GetTypeCount(Type T)
        {
            return _count[T];
        }
        protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    e.NewItems.Cast<Object>().ToList().ForEach(OnAdded);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    e.OldItems.Cast<Object>().ToList().ForEach(OnRemoved);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    // TODO: Handle this case
                    break;
                case NotifyCollectionChangedAction.Reset:
                    _count.Clear();
                    this.ToList().ForEach(OnAdded);
                    break;
            }
            base.OnCollectionChanged(e);
        }
        private void OnAdded(Object o)
        {
            _count[o.GetType()] += 1;
        }
        private void OnRemoved(Object o)
        {
            _count[o.GetType()] -= 1;
        }
    }
