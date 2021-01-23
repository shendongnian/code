    public SomethingListViewModel : ViewModelBase {
        
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
