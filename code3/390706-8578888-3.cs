        private void Form1_Load(object sender, EventArgs e)
		{
			SetupClickEvents(this);
		}
		/// <summary>
		/// This will loop through each control within the container and add a click handler to it
		/// </summary>
		/// <param name="container">The container whose children to handle clicks for</param>
		private void SetupClickEvents(Control container)
		{
			foreach(Control control in container.Controls)
			{
				control.Click += HandleClicks;
			}
		}
		private void HandleClicks(object sender, EventArgs e)
		{
			Control control = (Control)sender;
			MessageBox.Show(string.Format("{0} was clicked!", control.Name));
		}
