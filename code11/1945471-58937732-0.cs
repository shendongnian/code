    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            Loaded += UserControl1_Loaded;
            Unloaded += UserControl1_Unloaded;
        }
        private void UserControl1_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= UserControl1_Loaded;
            Window window = Window.GetWindow(this);
            window.PreviewKeyDown += Window_PreviewKeyDown;
        }
        private void UserControl1_Unloaded(object sender, RoutedEventArgs e)
        {
            Unloaded -= UserControl1_Unloaded;
            Window window = Window.GetWindow(this);
            window.PreviewKeyDown -= Window_PreviewKeyDown;
        }
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.R && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.LeftCtrl)))
            {
                var viewModel = DataContext as YourViewModel;
                if (viewModel != null)
                    viewModel.TakeCCommand.Execute();
            }
        }
    }
