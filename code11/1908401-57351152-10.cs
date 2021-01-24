    class EmployeeViewModel : ViewModelBase
    {
      protected override void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
      {
        base.NotifyPropertyChanged(propertyName);
        base.NotifyPropertyChanged(nameof(this.FullnameTitle));
      }
    
      ...
    }
