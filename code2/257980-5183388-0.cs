    [DataContract]
    public class SerializerTest : INotifyPropertyChanged, INotifyCollectionChanged
    {
        private DispatcherTimer _dT;
        public static string Key { get{return typeof (SerializerTest).FullName;} }
        
        public ObservableCollection<string> Strings { get; private set; }
        [DataMember]
        public string CurrentItem { get; private set; }
        public SerializerTest()
        {
            Strings = new ObservableCollection<string>();
            Strings.CollectionChanged += StringsCollectionChanged;
            CreateTimer();
        }
        private void StringsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CurrentItem = Strings[Strings.Count - 1];
            OnPropertyChanged("CurrentItem");
        }
        [OnDeserialized]
        public void Init(StreamingContext c)
        {
            CreateTimer();
        }
        private void CreateTimer()
        {
            _dT = new DispatcherTimer();
            _dT.Tick += (a, b) => Strings.Add(DateTime.Now.ToLongTimeString() + Strings.Count);
            _dT.Interval = new TimeSpan(0, 0, 0, 2);
            _dT.Start();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            if (CollectionChanged != null)
            {
                CollectionChanged(this, args);
            }
        }
    }
