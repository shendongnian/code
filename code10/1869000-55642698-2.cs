    public class MyClass : INotifyPropertyChanged
    {
        public List<string> _TestFire = new List<string>();
    
        [JsonProperty("StringProp")]
        string _StringProp;
        [JsonIgnore]
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
                    _TestFire.Add("StringProp was fired " + DateTime.Now);
                }
            }
        }
        ...
    }
