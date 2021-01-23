    private void button1_Click(object sender, EventArgs e)
	{
		try
		{
			Class1.testWithoutTC();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + Environment.NewLine + "In. Ex.: " + ex.InnerException);
		}
	}
	private void button2_Click(object sender, EventArgs e)
	{
		try
		{
			Class1.testWithTC1();
		}
		catch (Exception ex)
		{
				MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + Environment.NewLine + "In. Ex.: " + ex.InnerException);
		}
	}
	private void button3_Click(object sender, EventArgs e)
	{
		try
		{
			Class1.testWithTC2();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + Environment.NewLine + "In. Ex.: " + ex.InnerException);
		}
	}
