    private void DoTheThing()
		{
			try
			{
				while (true)
				{
					TheThing e = new TheThing();
					Thread t = new Thread(new ThreadStart(e.Run));
					t.Start();
					Thread.Sleep(1000);
				}
			}
			catch (ThreadAbortException) { }
			catch (Exception ex) { /* Whatever error handling you got */ }
		}
