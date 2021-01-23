    public MainPage()
    {
        InitializeComponent();
        service1 = new Service1Client();
        service1.GetDataCompleted += new EventHandler<GetDataCompletedEventArgs>(getDataCompleted); 
        
        service1.GetDataAsync(1);
    
        service2 = new Service1Client();
        service2.GetDataCompleted += new EventHandler<GetDataCompletedEventArgs>(getDataCompleted); 
        
        service2.GetDataAsync(2);
    }
