    private readonly ObservableCollection<ImageSource> imageList
        = new ObservableCollection<ImageSource>();
    public MainWindow()
    {
        InitializeComponent();
        ImageView.ItemsSource = imageList;
    }
