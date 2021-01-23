	private void button1_Click(object sender, EventArgs e)
	{
		button1.Enabled = false;
		MyConversionClass conversion = new MyConversionClass();
		conversion.Start(myinput, myoutput, SynchronizationContext.Current, this.conversion_Completed);
	}
	
	private void conversion_Completed(object sender, EventArgs e)
	{
		var output = (sender as MyConversionClass).Output;
		... your other stuff that uses output
		button1.Enabled = true;
	}
