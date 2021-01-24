		// Add these 2 class members.
		System.Timers.Timer _zoomTimer = new System.Timers.Timer();
        public double _lastZoomValue = 100; // default zoom
		
		
		// in the Startup function of the addin, set the timer.
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            _zoomTimer.Elapsed += OnZoomChanged;
            _zoomTimer.Interval = 1000;
            _zoomTimer.Start();
        }
        // dispose the timer
        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            _zoomTimer.Dispose();
        }
		
		// check if there is active window.
		private void OnZoomChanged(object source, ElapsedEventArgs e)
        {
            _zoomTimer.Stop();
            var app = this.Application;
            if (app!=null && app.ActiveWindow != null && app.ActiveWindow.Zoom != _lastZoomValue)
            {
                _lastZoomValue = app.Application.ActiveWindow.Zoom;
				// DO SOMETHING
            }
            _zoomTimer.Start();
        }
