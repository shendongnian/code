	private const int fullSpeed = 1;
	private const int reducedSpeed = 2;
	private int currentPistonPositon = 0; // global var updated by event as you described
	private async void button1_Click(object sender, EventArgs e)
	{
		int B = 50;
		int C = 75;
		pos(fullSpeed, B);
		await Task.Run(() =>
			{   // pick one below?
				// assumes that "B" and "currentPistonPosition" can actually be EXACTLY the same value
				while (currentPistonPositon != B) 
				{
					System.Threading.Thread.Sleep(25);
				}
				// if this isn't the case, then  perhaps when it reaches a certain threshold distance?
				while (Math.Abs(currentPistonPositon - B) > 0.10)
				{
					System.Threading.Thread.Sleep(25);
				}
			});
		pos(reducedSpeed, C);
	}
