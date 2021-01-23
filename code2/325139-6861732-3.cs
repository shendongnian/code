    public  class ViewModel : ViewModelBase
        {
            private List<Employee> _employes;
    
            public List<Employee> Employes
            {
                get { return _employes; }
                set { _employees = value; OnPropertyChanged("Employes"); }
            }
            private Employee _selectedEmploye;
    
            public Employee SelectedEmploye
            {
                get { return _selectedEmploye; }
                set
                {
                    _selectedEmployee = value;
                    OnPropertyChanged("SelectedEmploye");
                }
            }
    
        }
