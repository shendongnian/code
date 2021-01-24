		// not seeing your declaraction, so assuming it is a date/time field
		protected DateTime currentTime = DateTime.Now;
		// default to a minimum value
		private DateTime _lastTime = DateTime.MinValue;
		public void Update()
		{
			// just FYI, shortcut readability to loop vs indexing loop.
			// An array is an enumerable you can loop through directly
			foreach (var oneRobot in _Robots)
				oneRobot.UpdateRobot();
			// vs what you had
			// for (int i = 0; i < _Robots.Count; i++)
			//{
			//	_Robots[i].UpdateRobot();
			//}
			if (SplashKit.Rnd() < 0.02)
			{
				_Robots.Add(RandomRobot());
			}
			CheckCollisions();
			// if the first time ever in, just set the last time to whatever current IS and get out.
			// you would never increase as score or lives on the first instance as it is basically 0
			if (_lastTime == DateTime.MinValue)
			{
				_lastTime = currentTime;
				return;
			}
			// subtracting one date/time (expecting that as currentTime since not explicitly shown)
			// creates a "TimeSpan" object which represents the difference between two date/time fields.
			// if no full second has completed yet, get out.
			if ((currentTime - _lastTime).Seconds < 0)
				return;
			// a second HAS completed since the last measurement. Update Score and Lives
			_Score++;
			if (_Scrore % 15 == 0)
				_Lives++;
			// NOW, you can adjust, but if its a 1.3 second between cycles, you would be constantly
			// getting farther and farther from actual seconds.  So what I am proposing is to
			// take the last second and just add an absolute one second to it, so when the next
			// real Second cycle is complete, it should properly hit again.
			_lastTime = _lastTime.AddSeconds(1);
		}
