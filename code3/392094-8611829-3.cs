        public static readonly DependencyProperty StopwatchTimeProperty =
            DependencyProperty.Register("StopwatchTime", typeof(string), typeof(MainPage), new PropertyMetadata(string.Empty));
        public string StopwatchTime
        {
            get { return (string)GetValue(StopwatchTimeProperty); }
            set { SetValue(StopwatchTimeProperty, value); }
        }
