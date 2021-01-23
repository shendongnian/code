	using (EventWaitHandle wh = new EventWaitHandle(false, EventResetMode.ManualReset))
	{
	  int outdex = mediaServerMinConnections;
	  for (int i = 0; i < mediaServerMinConnections; i++)
	  {
	    new Thread(() =>
	    {
	      sshPool.Enqueue(new SshHandler());
	      if (Interlocked.Decrement(ref outdex) < 1)
	        wh.Set();
	    }).Start();
	  }
	  wh.WaitOne();
	}
