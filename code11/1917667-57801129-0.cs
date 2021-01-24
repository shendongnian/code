    public SwipeItems leftItems { get; set; }
    public MainPage()
    {
        this.InitializeComponent();
        SwipeItem leftItem = new SwipeItem();
        Binding myBinding = new Binding();
        myBinding.Source = viewmodel;
        myBinding.Path = new PropertyPath("MyText"); //the property in viewmodel
        BindingOperations.SetBinding(leftItem, SwipeItem.CommandParameterProperty, myBinding);
        BindingOperations.SetBinding(leftItem, SwipeItem.TextProperty, myBinding);
    
        Binding commandBinding = new Binding();
        commandBinding.Source = new FavoriteCommand(); //command class
        BindingOperations.SetBinding(leftItem, SwipeItem.CommandProperty, commandBinding);
    
        leftItems = new SwipeItems() {
            leftItem
        };
        this.DataContext = this;
      
    }
