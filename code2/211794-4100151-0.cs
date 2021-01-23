    public void SetText(string text)
	{
		// InvokeRequired required compares the thread ID of the
		// calling thread to the thread ID of the creating thread.
		// If these threads are different, it returns true.
		if (this.textBox1.InvokeRequired)
		{    
			SetTextCallback d = new SetTextCallback(SetText);
			this.Invoke(d, new object[] { text });
		}
		else
		{
			this.tbx_Log.Text = text;
		}
	}
