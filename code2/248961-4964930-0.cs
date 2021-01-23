    private HashSet<string> _ChangedProperties = new HashSet<string>();
    private void OnPropertyChanged(string propertyName)
    {
       if (_Suspended)
       {
          _ChangedProperties.Add(propertyName);
       }
       else
       {
          PropertyChangedEventHandler h = PropertyChanged;
          if (h != null)
          {
             h(this, new PropertyChangedEventArgs(propertyName));
          }
       }
    }
    private bool _Suspended;
    public bool Suspended
    {
       get { return _Suspended; }
       set
       {
          if (_Suspended == value)
          {
             return;
          }
          _Suspended = value;
          if (!_Suspended)
          {
             foreach (string propertyName in _ChangedProperties)
             {
                OnPropertyChanged(propertyName);
             }
             _ChangedProperties.Clear();
          }
       }
    }
