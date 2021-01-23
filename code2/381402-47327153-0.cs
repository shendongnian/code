    public class Prop<T> : INotifyPropertyChanged
    {
        private T _value;
    
        public T Value
        {
            get => _value; 
            set { _value = value; NotifyPropertyChanged(nameof(_value)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        internal void NotifyPropertyChanged(String propertyName) => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
