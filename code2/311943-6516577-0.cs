    private void ListenToPropertyChangedEvent(INotifyPropertyChanged source,
                                              string propertyName)
    {
        var listener = new MyPropertyChangedListener(propertyName);
        source.PropertyChanged += listener.Handle;
    }
    class MyPropertyChangedListener
    {
        private readonly string propertyName;
        public MyPropertyChangedListener(string propertyName)
        {
            this.propertyName = propertyName;
        }
        public void Handle(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == this.propertyName)
            {
                // do something
            }
        }
    }
