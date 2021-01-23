		private void button1_Click(object sender, EventArgs e) {
			const int MAX_BUTTONS = 1000;
			var stopWatch = new System.Diagnostics.Stopwatch();
			stopWatch.Start();
			for (int i = 0; i < MAX_BUTTONS; i++) {
				var button = new Button();
				button.Click += new EventHandler(button_Click);
			}
			stopWatch.Stop();
			System.Diagnostics.Debug.WriteLine(string.Format("button1_Click - Click_A: {0} ms", stopWatch.ElapsedMilliseconds));
			stopWatch.Reset();
			stopWatch.Start();
			EventHandler clickHandler = this.button_Click;
			for (int i = 0; i < MAX_BUTTONS; i++) {
				var button = new Button();
				button.Click += clickHandler;
			}
			stopWatch.Stop();
			System.Diagnostics.Debug.WriteLine(string.Format("button1_Click - Click_B: {0} ms", stopWatch.ElapsedMilliseconds));
			stopWatch.Start();
			for (int i = 0; i < MAX_BUTTONS; i++) {
				var button = new Button();
				button.MouseUp += new MouseEventHandler(button_MouseUp);
			}
			stopWatch.Stop();
			System.Diagnostics.Debug.WriteLine(string.Format("button1_Click - MouseUp_A: {0} ms", stopWatch.ElapsedMilliseconds));
			stopWatch.Reset();
			stopWatch.Start();
			MouseEventHandler mouseUpHandler = this.button_MouseUp;
			for (int i = 0; i < MAX_BUTTONS; i++) {
				var button = new Button();
				button.MouseUp += mouseUpHandler;
			}
			stopWatch.Stop();
			System.Diagnostics.Debug.WriteLine(string.Format("button1_Click - MousUp_B: {0} ms", stopWatch.ElapsedMilliseconds));
		}
