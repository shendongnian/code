    public static readonly DependencyProperty AppsProperty =
                DependencyProperty.Register("Apps", typeof (ObservableCollection<App>), typeof (YourClass), new PropertyMetadata(default(ObservableCollection<App>)));
    
    public ObservableCollection<App> Apps
    {
        get { return (ObservableCollection<App>) GetValue(AppsProperty); }
        set { SetValue(AppsProperty, value); }
    }
    
    public MainWindow()
    {
        Apps = LoadApps();
        listview.SetBinding(ListView.ItemsSourceProperty, new Binding("Apps"){Source = this})
    }
