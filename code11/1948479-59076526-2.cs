	private void button1_Click(object sender, EventArgs e)
	{
		int B = 50;
		int C = 75;
		GotoPosition(fullSpeed, B);
		GotoPosition(reducedSpeed, C);
	}
	private async void GotoPosition(int speed, int position)
	{
		pos(speed, position);
		await Task.Run(() =>
		{
			while (Math.Abs(currentPistonPositon - position) > 0.10)
			{
				System.Threading.Thread.Sleep(25);
			}
		});
	}
