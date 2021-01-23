    	private void Panel_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				Panel.Left += e.X - PanelMouseDownLocation.X;
				Panel.Top += e.Y - PanelMouseDownLocation.Y;
			}
		}
		private void Panel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left) PanelMouseDownLocation = e.Location;
		}
	public Point PanelMouseDownLocation { get; set; }
