    public EmployeeDTO SelectedEmployee
    {
        get { return selectedEmployee; }
        set
        {
            selectedEmployee = value;
            OnPropertyChanged(nameof(SelectedEmployee));
        }
    }
