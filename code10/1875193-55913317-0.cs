    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }
        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            await setdata();
        }
        public List<string> listS { get; set; } = new List<string>();
        public async Task setdata()
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
            {
                for (int i = 0; i < 30; i++)
                {
                    DataTemplate template = this.Resources["listT"] as DataTemplate;
                    var element = template.LoadContent() as UIElement;
                    ListView list = element as ListView;
                    for (int j = 0; j < 20; j++)
                    {
                        listS.Add("t: " + j);
                    }
                    list.DataContext = listS;
                    root.Children.Add(list);
                    await Task.Delay(1000);
                }
            });
        }
    }
