    public partial class MainPage : PhoneApplicationPage
    {
        DispatcherTimer dimmerTimer;
 
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            dimmerTimer = new DispatcherTimer();
            dimmerTimer.Tick += dimmerTimer_Tick;
            dimmerTimer.Interval = TimeSpan.FromSeconds(5);
            dimmerTimer.Start();
        }
        void dimmerTimer_Tick(object sender, EventArgs e)
        {
            DimDisplay();
        }
        void DimDisplay()
        {
            DimmerControl.Visibility = System.Windows.Visibility.Visible;
        }
        void UndimDisplay()
        {
            DimmerControl.Visibility = System.Windows.Visibility.Collapsed;
        }
        private void DimmerControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UndimDisplay();
        }
        private void Input1Value_TextChanged(object sender, TextChangedEventArgs e)
        {
            UndimDisplay();
            dimmerTimer.Stop();
            dimmerTimer.Start();
        }
    }
