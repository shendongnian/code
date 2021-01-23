    public class ObservableCollectionWithSubscribers<T> : ObservableCollection<T>
    {
        Action<string> _notificationAction = s => { }; // do nothing, by default
        readonly IList<string> _subscribedProperties = new List<string>();
        public void SubscribeToChanges(Action<string> notificationAction, params string[] properties)
        {
            _notificationAction = notificationAction;
            foreach (var property in properties)
                _subscribedProperties.Add(property);
        }
        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            NotifySubscribers();
        }
        protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e);
            NotifySubscribers();
        }
        void NotifySubscribers()
        {
            foreach (var property in _subscribedProperties)
                _notificationAction(property);
        }
    }
