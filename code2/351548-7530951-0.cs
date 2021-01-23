    public partial class MainWindow : Window
    {
        static MainWindow()
        {
            Window.TopmostProperty.OverrideMetadata(typeof(MainWindow),
                new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.None,
                    new PropertyChangedCallback(OnTopMostChanged)));
        }
        public event EventHandler TopmostChanged;
        private static void OnTopMostChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            MainWindow mv = (MainWindow)d;
            if (mv.TopmostChanged != null)
                mv.TopmostChanged(mv, EventArgs.Empty);
        }
        
        private void ChangeTopmostBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Topmost = !this.Topmost;
        }
        ...
    }
