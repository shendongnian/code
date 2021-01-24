    abstract class ViewModelBase : INotifyPropertyChaged
    {
      public ViewModelBase()
      {}
    
      public bool TryApplyPropertyChange<TValue>(TValue value, ref TValue targetField, [CallerMemberName] string propertyName = null)
      {  
        if (value.Equals(targetBackingField))
        {
          return false;
        }
    
        targetField = value;
        NotifyPropertyChanged(propertyName);
        this.IsDirty = true;
        return true;
      }
    
      public bool IsDirty { get; protected set; }
      protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
      {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
    }
