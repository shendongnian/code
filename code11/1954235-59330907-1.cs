    DateTime? _startTime;
	
	void pressSpacebar()
    {
        if (!Input.GetKeyDown("space")) return;
		if (_startTime.HasValue)
		{
			var duration = DateTime.Now - _startTime.Value;
			print("Timer ran for {0} seconds", duration.Seconds);
			_startTime = null;
		}
		else
		{
			_startTime = DateTime.Now;
			print("Timer started.");
		}
    }
