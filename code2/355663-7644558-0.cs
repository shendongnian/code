    private bool _isUpdating;
    private List<string> _properties = ...;
    private void RaisePropertyChanged(string propertyName)
    {
       if(_isUpdating) 
       {
         if(!_properties.Contains(propertyName)) _properties.Add(propertyName);
         return;
       } 
  
       PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
    void StartUpdating() { _isUpdating = true; }
  
    void EndUpdating()
    {
      _isUpdating = false;
      foreach(var propertyName in _properties) RaisePropertyChanged(propertyName);
    }
