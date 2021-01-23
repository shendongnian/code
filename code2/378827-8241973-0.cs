    public class DataViewModel : INotifyPropertyChanged
    {
        private Data _data;
        // Some data property.
        public Data Data { get { return _data; } set { ... } }
    
        private Visibility _visibility;
        // The visibility property.
        public Visibility Visibility { get { return _visibility; } set { ... } }
    }
