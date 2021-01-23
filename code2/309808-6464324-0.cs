	public void t1Start()
	{
		Console.WriteLine("t1Start started,  Mutex.WaitAll(Mutex[])");
		Mutex[] gMs = new Mutex[2] { gM1, gM2 };
		Mutex.WaitAll(gMs);  // Waits until both gM1 and gM2 are released
		Thread.Sleep(2000);
		Console.WriteLine("t1Start finished, Mutex.WaitAll(Mutex[]) satisfied");
		Event1.Set();      // AutoResetEvent.Set() flagging method is done
		gM1.ReleaseMutex();
		gM2.ReleaseMutex();
	}
	public void t2Start()
	{
		Console.WriteLine("t2Start started,  gM1.WaitOne( )");
		gM1.WaitOne();    // Waits until Mutex gM1 is released
		Console.WriteLine("t2Start finished, gM1.WaitOne( ) satisfied");
		Event2.Set();     // AutoResetEvent.Set() flagging method is done
		gM1.ReleaseMutex();
	}
	public void t3Start()
	{
		Console.WriteLine("t3Start started,  Mutex.WaitAny(Mutex[])");
		Mutex[] gMs = new Mutex[2] { gM1, gM2 };
		int mxObtained = Mutex.WaitAny(gMs);  // Waits until either Mutex is released
		Console.WriteLine("t3Start finished, Mutex.WaitAny(Mutex[])");
		Event3.Set();       // AutoResetEvent.Set() flagging method is done
		gMs[mxObtained].ReleaseMutex();
	}
	public void t4Start()
	{
		Console.WriteLine("t4Start started,  gM2.WaitOne( )");
		gM2.WaitOne();   // Waits until Mutex gM2 is released
		Console.WriteLine("t4Start finished, gM2.WaitOne( )");
		Event4.Set();    // AutoResetEvent.Set() flagging method is done
		gM2.ReleaseMutex();
	}
