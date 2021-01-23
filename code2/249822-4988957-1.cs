    public partial class TimerPage : UserControl
    {
        public TimerPage()
        {
            InitializeComponent();
            timerViewModel = new TimerViewModel();
            DataContext = timerViewModel;
        }
        private TimerViewModel timerViewModel;
    }
