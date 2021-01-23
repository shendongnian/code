        public MultiComboBox()
        {
            this.Loaded += new RoutedEventHandler(MultiComboBox_Loaded);
            this.Unloaded += new RoutedEventHandler(MultiComboBox_Unloaded);
        }
        void MultiComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            this._timer = new DispatcherTimer();
            this._timer.Interval = TimeSpan.FromMilliseconds(1000);
            this._timer.Tick += new EventHandler(_timer_Tick);
        }
        void MultiComboBox_Unloaded(object sender, RoutedEventArgs e)
        {
            if (this._timer != null)
            {
                this._timer.Stop();
                this._timer = null;
            }
        }
        void _timer_Tick(object sender, EventArgs e)
        {
            this._timer.Stop();
            this._textSought = string.Empty;
        }
        private DispatcherTimer _timer;
        private string _textSought = string.Empty;
