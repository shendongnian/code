    private DispatcherTimer tmr = new DispatcherTimer();
    private List<string> images = new List<string>();
    private int imageIndex = 0;
    public MainPage()
    {
        InitializeComponent();
        Loaded += new RoutedEventHandler(MainPage_Loaded);
    }
    void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        tmr.Interval = TimeSpan.FromSeconds(5);
        tmr.Tick += new EventHandler(tmr_Tick);
        LoadImages();
        ShowNextImage();
    }
    private void LoadImages()
    {
        // list the files (includede in the XAP file) here
        images.Add("/images/filename1.jpg");
        images.Add("/images/filename2.jpg");
        images.Add("/images/filename3.jpg");
        images.Add("/images/filename4.jpg");
    }
    private void ShowNextImage()
    {
        var bi = new BitmapImage(new Uri(images[imageIndex], UriKind.Relative));
        myImg.Source = bi;
        imageIndex = (imageIndex + 1) % images.Count;
    }
    void tmr_Tick(object sender, EventArgs e)
    {
        ShowNextImage();
    }
    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
        if (!tmr.IsEnabled)
        {
            tmr.Start();
        }
        base.OnNavigatedTo(e);
    }
    protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
    {
        tmr.Stop();
        base.OnNavigatedFrom(e);
    }
