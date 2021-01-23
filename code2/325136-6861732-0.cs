    public  class ViewModel : ViewModelBase
        {
            private List<Employee> _employees;
    
            public List<Employee> Employees
            {
                get { return _employees; }
                set { _employees = value; OnPropertyChanged("Employes"); }
            }
            private Employee _selectedEmployee;
    
            public Employee SelectedEmployee
            {
                get { return _selectedEmployee; }
                set
                {
                    _selectedEmployee = value;
                    OnPropertyChanged("SelectedEmploye");
                }
            }
    
        }
