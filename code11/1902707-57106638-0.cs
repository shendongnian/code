    private void button1_Click_1(object sender, EventArgs e)
	{
		try
		{
			if (sliderKernel.Value % 2 == 0)
				throw new Exception("Enter an odd number");
			
			// handle odd numbers here
		}
		catch(Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}
