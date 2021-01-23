    public ObservableCollection<Basket> baskets = new ObservableCollection<Basket>(); 
    public pivotPage() 
    { 
        InitializeComponent(); 
        
        this.DataContext = baskets;
        //for testing purposes 
        baskets.Add(new Basket()); 
        baskets.Add(new Basket()); 
    } 
