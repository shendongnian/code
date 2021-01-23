    public MainWindow()
            {
                InitializeComponent();
    
                Employee emp = new Employee();
                DataContext = emp.GetEmployees();
    
            }
