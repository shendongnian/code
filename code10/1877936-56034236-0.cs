    public abstract class NotifyBase : INotifyPropertyChanged
    {
      private readonly Dictionary<string, object> mapping;
    
      protected NotifyBase()
      {
        mapping = new Dictionary<string, object>();
      }
    
      protected void Set<T>(T value, [CallerMemberName] string propertyName = "")
      {
        mapping[propertyName] = value;
        OnPropertyChanged(propertyName);
      }
    
      protected T Get<T>([CallerMemberName] string propertyName = "")
      {
        if(mapping.ContainsKey(propertyName))
          return (T)mapping[propertyName];
        return default(T);
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
    
      protected virtual void OnPropertyChanged([CallerMemeberName] string propertyName = null)
      {
        PropertyChangedEventHandler handler = PropertyChanged;
        if(handler != null)
        {
          handler(this, new PropertyChangedEventArgs(propertyName));
        }
      }
    }
  
    
