    public abstract class StateParameter<T> : IStateParameter, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string State { get; set; }
        public T Value
        {
            get { return _v; }
            set
            {
                if ((_v as IEquatable<T>)?.Equals(value) == true || ReferenceEquals(_v, value) || _v?.Equals(value) == true)
                    return;
                _v = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
            }
        }
        private T _v;
        object IStateParameter.Value
        {
            get { return this.Value; }
            set { this.Value = (T) value; }
        }
    }
