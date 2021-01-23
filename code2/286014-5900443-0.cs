        private Timer _timer = new System.Windows.Forms.Timer();
        private bool _processingText;
        public MyRichTextBox()
        {
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += new EventHandler(ProcessText);
        }
        protected override void OnTextChanged(EventArgs e)
        {
            if (_processingText == false)
            {
                _timer.Stop();
                _timer.Start();
            }
        }
        private void ProcessText(object sender, EventArgs e)
        {
            _processingText = true;
            _timer.Stop();
            // Insert your processing logic here
            _processingText = false;
        }
