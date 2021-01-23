    public MainPage()
    {
        InitializeComponent();
        ObservableCollection<SampleData> dataSource = new ObservableCollection<SampleData>();
        dataSource.Add(
            new SampleData()
            {
                ImageUri = "Images/appbar.delete.rest.png",
                Text = "Item1",
                Description = "blablabla",
                TargetUri = new Uri("Page1.xaml", UriKind.Relative)
            });
        dataSource.Add(
            new SampleData()
            {
                ImageUri = "Images/appbar.delete.rest.png",
                Text = "item2",
                Description = "blablabla",
                TargetUri = new Uri("Page2.xaml", UriKind.Relative)
            });
        dataSource.Add(
            new SampleData()
            {
                ImageUri = "Images/appbar.download.rest.png",
                Text = "Item3",
                Description = "blablabla",
                TargetUri = new Uri("Page3.xaml", UriKind.Relative)
            });
        this.list.ItemsSource = dataSource;
    }
    private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var data = list.SelectedItem as SampleData;
        if (data == null)
        {
            return;
        }
        NavigationService.Navigate(data.TargetUri);
    }
    public class SampleData
    {
        public string Text { get; set; }
        public string Description { get; set; }
        public string ImageUri { get; set; }
        public Uri TargetUri { get; set; }
    }
