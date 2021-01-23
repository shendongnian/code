    class WcfModel : IWcfModel
    {
        private ObservableCollection<ConsoleData> _dataList;
    
        public WcfModel ()
        {
            _dataList = new ObservableCollection<ConsoleData>();
            _dataList.CollectionChanged += DataArrived
    
        }
        public ObservableCollection<ConsoleData> DataList
        {
            get { return _dataList; }
        }
    
        public event Action<object, NotifyCollectionChangedEventArgs> DataArrived;
    }
