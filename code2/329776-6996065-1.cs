    public partial class MainPage: UserControl
    {
        DispatcherTimer timer = new DispatcherTimer();
        public MainPage()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainPage_Loaded);
            Unloaded += new RoutedEventHandler(MainPage_Unloaded);
        }
        void MainPage_Unloaded(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }
        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += (s, args) =>
            {
                FrameworkElement innerControl = txt.Descendents(1).First() as FrameworkElement;
                result.ItemsSource = VisualStateManager.GetVisualStateGroups(innerControl).OfType<VisualStateGroup>()
                    .Select(vsg => vsg.Name + " : " + (vsg.CurrentState != null ? vsg.CurrentState.Name : "<none>"));
            };
            timer.Start();    
        }
    }
