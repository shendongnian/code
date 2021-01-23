    public partial class DelayedTextBox : UserControl
    {
        private DispatcherTimer eventTimer = new DispatcherTimer();
        public double TextChangedDelay
        {
            get { return eventTimer.Interval.TotalMilliseconds; }
            set { eventTimer.Interval = TimeSpan.FromMilliseconds(value); }
        }
        public delegate void DelayedTextChangedHandler(object sender, RoutedEventArgs e);
        public event DelayedTextChangedHandler DelayedTextChange;
        private object relayedSender = null;
        private RoutedEventArgs relayedE = null;
        public string Text
        {
            get
            {
                return PlainTextBox.Text;
            }
            set
            {
                PlainTextBox.Text = string.IsNullOrEmpty(value) ? string.Empty : value;
            }
        }
        //----------------------------------------------------------------------------------------------
        public TimedTextChangedTextBox()
        {
            InitializeComponent();
            TextChangedDelay = 500;
            eventTimer.Tick += new EventHandler(eventTimer_Tick);
        }
        private void StartTimer(object sender, RoutedEventArgs e)
        {
            relayedSender = sender;
            relayedE = e;
            eventTimer.Start();
        }
        private void StopTimer()
        {
            eventTimer.Stop();
            relayedSender = null;
            relayedSender = null;
        }
        private void eventTimer_Tick(object sender, EventArgs e)
        {
            StopTimer();
            if (DelayedTextChange != null)
                DelayedTextChange(relayedSender, relayedE);
        }
        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!maskedInput)
                ReactToInput(sender, e);
        }
        private void ReactToInput(object sender, RoutedEventArgs e)
        {
            if (!eventTimer.IsEnabled)
            {
                StartTimer(sender, e);
            }
            else
            {
                StopTimer();
                StartTimer(sender, e);
            }
        }
    }
