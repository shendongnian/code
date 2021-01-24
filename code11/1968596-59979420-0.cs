    public MainPage()
    {
        this.InitializeComponent();
        pageCollection = new ObservableCollection<ViewModel>();
        CanvasListView.ItemsSource = pageCollection;
        CanvasListView.IsHitTestVisible = true;
        //Or
        //CanvasListView.IsHitTestVisible = false;
    }
