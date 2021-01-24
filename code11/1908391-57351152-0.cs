    class EmployeeViewModel : ViewModelBase
    {
      public EmployeeViewModel()
      {
        this.PropertyChanged += (s, e) => OnPropertyChanged(nameof(this.FullnameTitle));
      }
    
      ...
    }
