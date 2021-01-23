    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            timer = new Timer(TimerElapsed);
        }
        // hold the timer in a variable to prevent it from being garbage collected
        private Timer timer = null;
        private void TimerElapsed(object state)
        {
            // important: this line puts the timer call into UI thread
            Dispatcher.BeginInvoke(() => {
                // your code goes here...
                // reload the page (this will reload the app and stop the timer!)
                HtmlPage.Window.Eval("location.reload()");
            });
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // start the timer in 1 second and repeat every 5 seconds
            timer.Change(1000, 5000);
        }
    }
