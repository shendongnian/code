	private void Form1_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
	{
		if (MessageBox.Show("Are you sure to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
		{
			e.Cancel = false;
		}
		else
		{
			e.Cancel = true;
		}
	}
