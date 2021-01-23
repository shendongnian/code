	private void SomeOtherMethod()
	{
		Action action = () => pictureBox1.Image = Image.FromFile("example.png");
		if (pictureBox1.InvokeRequired)
		{
			Invoke(action);
		}
		else
		{
			action();
		}
	}
