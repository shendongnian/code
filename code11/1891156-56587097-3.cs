	int lastIndex = 0;
	private void BtnKerko_Click(object sender, EventArgs e)
	{
		txtUser.Focus();
		int index = txtUser.Text.IndexOf(txtKerko.Text, lastIndex);
		if (index != -1)
		{
			lastIndex = index + 1;
			txtUser.SelectionStart = index;
			txtUser.SelectionLength = txtKerko.TextLength;
		}
	}
