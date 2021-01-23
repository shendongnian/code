    using System.Windows.Threading;
    
    class MyWindow : Window
    {
        public MyWindow()
        {
            _someLabel.Text = "Whatever";
            var timer = new DispatcherTimer();
            timer.Interval = Timespan.FromSeconds( 15 );
            timer.Tick += delegate { _someLabel.Text = String.Empty; };
        }
    }
