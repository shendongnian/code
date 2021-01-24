    [Serializable]
    public class Property<T>: INotifyPropertyChanged
    {
        protected T _Value;
        public T Value
        {
            get
            {
                return Value;
            }
            set
            {
                _Value = value;
                NotifyPropertyChanged();
            }
        }
        #region Implementation of INotifyPropertyChanged interface
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
