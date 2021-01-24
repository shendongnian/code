        //create a dependency property you can bind to
        public int Counter
        {
            get { return (int)this.GetValue(CounterProperty); }
            set { this.SetValue(CounterProperty, value); }
        }
        public static readonly DependencyProperty CounterProperty =
            DependencyProperty.Register(nameof(Counter), typeof(int), typeof(MainWindow), new PropertyMetadata(default(int)));
        //Create a timer that runs one second and decreases CountDown when elapsed
        Timer t = new Timer();
        t.Interval = 1000;
        t.Elapsed += CountDown;
        t.Start();
        //restart countdown when value greater one
        private void CountDown(object sender, ElapsedEventArgs e)
        {
            if (counter > 1)
            {
                (sender as Timer).Start();
            }
            Counter--;
        }
