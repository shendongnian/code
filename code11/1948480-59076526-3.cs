	private void button1_Click(object sender, EventArgs e)
	{
		int B = 50;
		int C = 75;
		if (GotoPosition(fullSpeed, B, TimeSpan.FromMilliseconds(750)).Result)
		{
			if (GotoPosition(reducedSpeed, C, TimeSpan.FromMilliseconds(1500)).Result)
			{
				// ... we successfully went to B at fullSpeed, then to C at reducedSpeed ...
			}
			else
			{
				MessageBox.Show("Piston Timed Out");
			}
		}
		else
		{
			MessageBox.Show("Piston Timed Out");
		}
		
	}
	private async Task<bool> GotoPosition(int speed, int position, TimeSpan timeOut)
	{
		pos(speed, position); // call the async API
		// wait for the position to be reached, or the timeout to occur
		bool success = true; // assume we have succeeded until proven otherwise
		DateTime dt = DateTime.Now.Add(timeOut); // set our timeout DateTime in the future
		await Task.Run(() =>
		{
			System.Threading.Thread.Sleep(50); // give the piston a chance to update maybe once before checking?
			while (Math.Abs(currentPistonPositon - position) > 0.10) // see if the piston has reached our target position
			{
				if (DateTime.Now > dt) // did we move past our timeout DateTime?
				{
					success = false;
					break;
				}
				System.Threading.Thread.Sleep(25); // very small sleep to reduce CPU usage
			}
		});
		return success;
	}
