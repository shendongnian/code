	public void writeToTextBoxEvent(object sender, DataReceivedEventArgs e)
	{
		if(this.textBox1.InvokeRequired)
		{
			this.textBox1.BeginInvoke(() => writeToTextBoxEvent(sender, e));
		}
		else
		{
			textBox1.Text = e.Data;
		}
	}
