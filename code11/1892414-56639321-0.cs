csharp
    private EmployeeModel _employee;
    public EmployeeModel Employee {
        get { return _employee; }
        set {
            if(_employee!=value) {
                _employee=value;
                OnPropertyChanged();
            }
         }
    }
