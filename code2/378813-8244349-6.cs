    public SomethingListViewModel : ViewModelBase {
        ................
        // This list we will use as a lookup in our drop-down column
        public IList<Order> OrderLookup { get; private set; }
        ................
        public IList<SomethingModel> _Items;
        public IList<SomethingModel> Items {
            get {
               return _Items;
            }
            private set {
               if (_Items == value) return;
               _Items = value;
               NotifyPropertyChanged("Items");
            }
        }
        ................
    }
