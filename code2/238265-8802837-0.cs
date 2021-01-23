	class YourDevice : GraphicsDeviceControl
	{
		private Stopwatch timer;
		protected override void Initialize()
		{
			timer = Stopwatch.StartNew();
			Application.Idle += delegate { Invalidate(); };
		}
			
		protected override void Draw()
		{
			Update(timer.Elapsed);
		}
		private void Update(TimeSpan gameTime)
		{
			// etc
		}
	}
