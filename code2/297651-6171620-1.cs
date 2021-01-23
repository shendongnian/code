	public static void InvokeIfRequired(Control control, Action action)
	{
		if (control.InvokeRequired)
		{
			control.Invoke(action);
		}
		else
		{
			action();
		}
	}
	
	private void SomeOtherMethod()
	{
		InvokeIfRequired(() => pictureBox1.Image = Image.FromFile("example.png");
	}
	   
