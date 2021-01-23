    private Department _selectedDepartment;
    public Department SelectedDepartment
    {
       get
          { return _selectedDepartment; } 
       set
          {
              _selectedDepartment = value;
              OnPropertyChanged("SelectedDepartment");
          }
    }
