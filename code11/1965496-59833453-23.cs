    ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
    public ObservableCollection<Employee> Employees { get { return employees; }}
    
    public ViewModel()
    {
        // is set and the UI will react to changes
        employees.Add(new Employee{ DisplayID = 1 , DisplayName="Rob Finnerty"});
        employees.Add(new Employee{ DisplayID = 2 , DisplayName="Bill Wrestler"});
        employees.Add(new Employee{ DisplayID = 3 , DisplayName="Dr. Geri-Beth Hooper"});
        employees.Add(new Employee{ DisplayID = 4 , DisplayName="Dr. Keith Joyce-Purdy"});
        employees.Add(new Employee{ DisplayID = 5 , DisplayName="Sheri Spruce"});
        employees.Add(new Employee{ DisplayID = 6 , DisplayName="Burt Indybrick"});
    }
