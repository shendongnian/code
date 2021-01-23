    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        static MainWindow() {
            EventManager.RegisterClassHandler(typeof(UIElement), Mouse.GotMouseCaptureEvent, new MouseEventHandler(MainWindow_GotMouseCapture));
        }
        static void MainWindow_GotMouseCapture(object sender, MouseEventArgs e) {
            // e.OriginalSource is a captured element
        }
    }
