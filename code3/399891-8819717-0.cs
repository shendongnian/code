        private void StartTimer()
		{
			TimeSpan ts = new TimeSpan(0, 0, 5, 0); 
			
			System.Windows.Threading.DispatcherTimer myDispatcherTimer = new System.Windows.Threading.DispatcherTimer();
			myDispatcherTimer.Interval = ts; 
			myDispatcherTimer.Tick += new EventHandler(Each_Tick);
			myDispatcherTimer.Start();
		}
		private void Each_Tick(object o, EventArgs sender)
		{
			//Your Method here
		}
