    struct Readonly<T>
    {
        private T _value;
        private bool _hasValue;
        public T Value
        {
            get
            {
                if (!_hasValue)
                    throw new InvalidOperationException();
                return _value;
            }
            set
            {
                if (_hasValue)
                    throw new InvalidOperationException();
                _value = value;
            }
        }
    }
    [DataContract]
    public sealed class Configuration
    {
        private Readonly<string> _version;
        [DataMember]
        public string Version
        {
            get { return _version.Value; }
            set { _version.Value = value; }
        }
    }
