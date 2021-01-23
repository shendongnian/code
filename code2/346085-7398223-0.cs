    public MainPage(){
      InitializeComponent();
      this.Loaded += new System.Windows.RoutedEventHandler(MainPage_Loaded);
    }
    private void MainPage_Loaded(object sender, System.Windows.RoutedEventArgs e){
      Storyboard1.Begin();
    }
