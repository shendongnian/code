    public class MyClass : INotifyPropertyChanged
    {
        public List<string> _TestFire = new List<string>();
        string _StringProp;
        public string StringProp
        {
            get
            {
                return _StringProp;
            }
            set
            {
                if (_StringProp != value)
                {
                    _StringProp = value;
                    RaisePropertyChanged("StringProp");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            // don't raise the event if the property is being changed due to deserialization	
            if (_isDeserializing) return;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            _TestFire.Add(propertyName + " was fired " + DateTime.Now);
        }
        bool _isDeserializing = false;
        [OnDeserializing]
        internal void OnDeserializingMethod(StreamingContext context)
        {
            _isDeserializing = true;
        }
        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            _isDeserializing = false;
        }
    }
