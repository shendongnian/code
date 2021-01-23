    public void PhysicsThread()
    {
    	int milliseconds = TimeSpan.FromTicks(333333).Milliseconds;
    	var stopwatch=System.Diagnostics.Stopwatch.StartNew();
    
    	while(true)
    	{
    		System.Threading.Thread.Sleep(milliseconds );
    
    		world.Step(stopwatch.ElapsedTicks);
    		stopwatch.Restart();
    	}
    }
