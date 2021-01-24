    public MainPage()
    {
        this.InitializeComponent();
        foreach (var item in NPPngv.MenuItems.OfType<NavigationViewItem>())
        {
            item.IsEnabled = false;
        }
    }
