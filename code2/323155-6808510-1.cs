    private Customer tmp;    
    public Customer Tmp {
        get {
            return this.tmp;
        }
        set {
            this.tmp = value;
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs("Tmp"));
        }
    }
    public MainWindow()
    {
        InitializeComponent();
        ar.Add(new Customer { FirstName = "qwe", LastName = "rty" });
        ar.Add(new Customer { FirstName = "asd", LastName = "asd" });
        this.Tmp = ar[index];
        this.SetBinding(DataContextProperty, new Binding("Tmp") { Source = this });
    }
