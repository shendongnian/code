    protected void OnPropertyChanged(string propertyName)
    {
       if (SuppressPropertyChanged)
       {
          return;
       }
       PropertyChangedEventHandler h = PropertyChanged;
       if (h != null)
       {
          h(this, new PropertyChangedEventArgs(propertyName);
       }
    }
    private bool _SuppressPropertyChanged;
    public bool SuppressPropertyChanged
    {
       get { return _SuppressPropertyChanged; }
       set
       {
          if (_SuppressPropertyChanged != value)
          {
             _SuppressPropertyChanged = value;
             if (!_SuppressPropertyChanged)
             {
                PropertyChangedEventHandler h = PropertyChanged;
                if (h != null)
                {
                   // using null tells the listener to refresh all properties
                   h(this, new PropertyChangedEventArgs(null);
                }
             }
          }
       }
