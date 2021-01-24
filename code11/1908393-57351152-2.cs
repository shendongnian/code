    class EmployeeViewModel : ViewModelBase
    {
      public EmployeeViewModel()
      {
        this.PropertyChanged += (s, e) => NotifyPropertyChanged(nameof(this.FullnameTitle));
      }
    
      ...
    }
