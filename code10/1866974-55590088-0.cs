    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Loaded += MainPage_Loaded;
        }
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            WeekInputViewModel viewModel = DataContext as WeekInputViewModel;
            if (viewModel != null)
                viewModel.SaveCommand.Execute(null);
        }
    }
