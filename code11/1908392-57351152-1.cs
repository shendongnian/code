    abstract class ViewModelBase : INotifyPropertyChanged
    {
      private bool IsInvokingPropertyChangedCallBack { get; set; }
    
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
        // Lock method in case OnPropertyChanged is used as PropertyChanged callback
        // (prevent infinite loop)
        if (this.IsInvokingPropertyChangedCallBack)
        {
          return;
        }
    
        this.IsInvokingPropertyChangedCallBack = true;
    
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    
        this.IsInvokingPropertyChangedCallBack = false;
      }
    } 
