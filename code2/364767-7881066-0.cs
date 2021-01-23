    // Constructor
    public MainViewModel()
    {
      // It would be better to use dependency injection here
      this.MyControlViewModel = new MyControlViewModel();     
    }
    public MyControlViewModel MyControlViewModel
    {
      get { return this.myControlViewModel; }
      set { this.myControlViewModel = value; this.NotifyOfPropertyChanged(...); }
    }
