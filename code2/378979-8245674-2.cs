	private void Form1_Load(object sender, EventArgs e)
		{
			Task t = new Task(() => DoSomething());
			t.Start();
			// Task completed, continue
			t.ContinueWith(task => true);
		}
		private void DoSomething()
		{
			for (int i = 0; i < 50; i++)
			{
				UpdateLabel();
				Thread.Sleep(500);
			}
		}
		private void UpdateLabel()
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke(new Action(() => UpdateLabel()), new object[] { });
			}
			else
			{
				label1.Text += ".";
				if (label1.Text.Length >= 5)
					label1.Text = ".";
			}
		}
