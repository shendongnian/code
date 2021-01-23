    public class ExpandingContainer : INotifyPropertyChanged {
        public object Payload { get; private set; }
        public ObservableCollection<ExpandingContainer> Children { get; private set; }
        public ExpandingContainer( object payload ) { ... }
        private bool _isexpanded;
        public bool IsExpanded {
            get { return _isexpanded; }
            set {
                if ( value == _isexpanded )
                    return;
                _isexpanded = value;
                PropertyChanged.Notify( () => IsExpanded );
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = (o,e) => {};
    }
