        private int _clicks = 0;
        private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
        private void txtTextMessage_MouseUp(object sender, MouseEventArgs e)
        {
            _timer.Stop();
            _clicks++;
            if (_clicks == 3)
            {
                // this means the trip click happened - do something
                txtTextMessage.SelectAll();
                _clicks = 0;
            }
            if (_clicks < 3)
            {
                _timer.Interval = 500;
                _timer.Start();
                _timer.Tick += (s, t) =>
                {
                    _timer.Stop();
                    _clicks = 0;
                };
            }
        }
