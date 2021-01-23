    public class Setting<T> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event Action<T> Changed;
        private readonly T _defaultValue;
        private T _value;
        public Setting(T defaultValue)
        {
            _defaultValue = defaultValue;
            _value = defaultValue;
        }
        public T Value
        {
            get { return _value; }
            set
            {
                if (Equals(_value, value))
                    return;
                _value = value;
                var evt = Changed;
                if (evt != null)
                    evt(value);
                var evt2 = PropertyChanged;
                if (evt2 != null)
                    evt2(this, new PropertyChangedEventArgs("Value"));
            }
        }
        public void ResetToDefault()
        {
            Value = _defaultValue;
        }
    }
