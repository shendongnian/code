    Data<Person> p;
    public MainWindow()
    {
        InitializeComponent();
        List<Data<Person>> list = new List<Data<Person>>();
        this.p = new Data<Person> { MyData = new Person { Name = "Sam", Age = 21 } };
        list.Add(this.p);
        this.DataContext = list;
    }
    private void listbox1_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        p.DataContext = null;
    }
