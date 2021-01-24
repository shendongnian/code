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
    
      private bool isDirty;
      public bool IsDirty 
      { 
        get => return this.isDirty; 
        protected set
        {
          if (Equals(value, this.isDirty)) return;
          this.isDirty = value;
          NotifyPropertyChanged(); 
        }
      }
      protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
      {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
    }
