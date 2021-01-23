    private Department _selectedDepartment;
    public Department SelectedDepartment
    {
       get
          { return _selectedDepartment;}   //return this.Employee.Department; 
       set
          {
              _selectedDepartment = value;
                                                                   //this.Employee.Department = value;
              OnPropertyChanged("SelectedDepartment");
          }
    }
