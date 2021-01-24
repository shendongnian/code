    ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
    public ObservableCollection<Employee> Employees { get { return employees; }}
    
    public ViewModel()
    {
        // is set and the UI will react to changes
        employees.Add(new Employee{ DisplayName="Rob Finnerty"});
        employees.Add(new Employee{ DisplayName="Bill Wrestler"});
        employees.Add(new Employee{ DisplayName="Dr. Geri-Beth Hooper"});
        employees.Add(new Employee{ DisplayName="Dr. Keith Joyce-Purdy"});
        employees.Add(new Employee{ DisplayName="Sheri Spruce"});
        employees.Add(new Employee{ DisplayName="Burt Indybrick"});
    }
