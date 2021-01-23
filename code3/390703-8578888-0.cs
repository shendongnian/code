        private void Form1_Load(object sender, EventArgs e)
		{
			SetupClickEvents();
		}
		private void SetupClickEvents()
		{
			foreach(Control control in this.Controls)
			{
				control.Click += (s, e) => { HandleClicks(s, e); };
			}
		}
		private void HandleClicks(object sender, EventArgs e)
		{
			Control control = (Control)sender;
			MessageBox.Show(string.Format("{0} was clicked!", control.Name));
		}
