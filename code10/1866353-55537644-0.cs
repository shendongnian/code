	if(proc != null)
	{
		if (!proc.HasExited)
			proc.Kill();
		proc = null;
	}
	else
	{
		th = new Thread(thread1);
		th.Start();   
	}
