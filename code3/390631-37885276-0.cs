    public abstract class INPCBase : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected bool OnPropertyChanging<T>(string propertyName, T originalValue, T newValue)
        {
            var handler = this.PropertyChanging;
            if (handler != null)
            {
                var args = new PropertyChangingCancelEventArgs<T>(propertyName, originalValue, newValue);
                handler(this, args);
                return !args.Cancel;
            }
            return true;
        }
        protected void OnPropertyChanged<T>(string propertyName, T previousValue, T currentValue)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs<T>(propertyName, previousValue, currentValue));
        }
    }
    public class PropertyChangingCancelEventArgs : PropertyChangingEventArgs
    {
        public bool Cancel { get; set; }
        public PropertyChangingCancelEventArgs(string propertyName)
            : base(propertyName)
        {
        }
    }
    public class PropertyChangingCancelEventArgs<T> : PropertyChangingCancelEventArgs
    {
        public T OriginalValue { get; private set; }
        public T NewValue { get; private set; }
        public PropertyChangingCancelEventArgs(string propertyName, T originalValue, T newValue)
            : base(propertyName)
        {
            this.OriginalValue = originalValue;
            this.NewValue = newValue;
        }
    }
    public class PropertyChangedEventArgs<T> : PropertyChangedEventArgs
    {
        public T PreviousValue { get; private set; }
        public T CurrentValue { get; private set; }
        public PropertyChangedEventArgs(string propertyName, T previousValue, T currentValue)
            : base(propertyName)
        {
            this.PreviousValue = previousValue;
            this.CurrentValue = currentValue;
        }
    }
