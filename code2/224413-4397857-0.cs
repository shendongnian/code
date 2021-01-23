	protected override void OnHelpButtonClicked(CancelEventArgs e)
	{
		e.Cancel = true;
		base.OnHelpButtonClicked(e);
		MessageBox.Show("Help goes here.");
	}
