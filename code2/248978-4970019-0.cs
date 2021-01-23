    public partial class MainWindow : Window
    {
        readonly DispatcherTimer activityTimer;
        public MainWindow()
        {
            InitializeComponent();
            InputManager.Current.PreProcessInput += Activity;
            activityTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(10),
                IsEnabled = true
            };
            activityTimer.Tick += Inactivity;
        }
        
        void Inactivity(object sender, EventArgs e)
        {
            rectangle1.Visibility = Visibility.Hidden;
        }
        void Activity(object sender, PreProcessInputEventArgs e)
        {
            // extend if you need: StylusEventArgs, TouchEventArgs etc.
            if (e.StagingItem.Input is MouseEventArgs ||
                e.StagingItem.Input is KeyboardEventArgs)
            {
                rectangle1.Visibility = Visibility.Visible;
                activityTimer.Stop();
                activityTimer.Start();
            }
        }
    }
