    class PropertyChangingCancelEventArgs : PropertyChangingEventArgs
    {
        public bool Cancel { get; set; }
        public PropertyChangingCancelEventArgs(string propertyName)
            : base(propertyName)
        {
        }
    }
    class PropertyChangingCancelEventArgs<T> : PropertyChangingCancelEventArgs
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
    class PropertyChangedEventArgs<T> : PropertyChangedEventArgs
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
