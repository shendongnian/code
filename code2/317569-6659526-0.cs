    public IList<Employee> Employees
    {
        get; 
        private set;
    }
    // in your constructor:
    this.Employees = new ObservableCollection<Employee>();
