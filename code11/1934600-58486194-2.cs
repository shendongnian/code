	private bool recentlyDeactivated = false;
	protected override void OnMouseUp(MouseEventArgs e)
	{
		base.OnMouseUp(e);
		if (recentlyDeactivated)
		{
			if (e.Button == MouseButtons.None)
			{
				MessageBox.Show("Mouse button press not recognized");
			}
			else
			{
				MessageBox.Show("Mouse button pressed");
			}
		}
		recentlyDeactivated = false;
	}
	void dropDownDeactivate(object sender, EventArgs e)
	{
		recentlyDeactivated = true;
	}
