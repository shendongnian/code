    abstract class ViewModelBase : INotifyPropertyChanged
    {
      private bool IsInvokingPropertyChangedCallBack { get; set; }
    
      protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
      {
        // Lock method in case NotifyPropertyChanged is used as PropertyChanged callback
        // (prevent infinite loop or infinite recursion)
        if (this.IsInvokingPropertyChangedCallBack)
        {
          return;
        }
    
        this.IsInvokingPropertyChangedCallBack = true;
    
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    
        this.IsInvokingPropertyChangedCallBack = false;
      }
    } 
