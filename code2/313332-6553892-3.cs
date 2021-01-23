	static void Main(string[] args)
	{
	    StaSynchronizationContext context = new StaSynchronizationContext();
	    StaSynchronizationContext.SetSynchronizationContext(context);
	    Console.WriteLine("Starting on {0}", Thread.CurrentThread.ManagedThreadId);
	    for (var i = 0; i < 10; i++)
	    {
	        var num = i;
	        Task<int>.Factory.StartNew(() =>
	        {
	            if (num == 3)
	            {
	                Thread.Sleep(20000);
	            }
	            Thread.Sleep(new Random(num).Next(1000, 10000));
	            Console.WriteLine("Done {0} on {1}", num, Thread.CurrentThread.ManagedThreadId);
	            return num;
	        }).ContinueWith(
	        value =>
	        {
	            Console.WriteLine("Completed {0} on {1}", value.Result, Thread.CurrentThread.ManagedThreadId);
	        }
	       ,TaskScheduler.FromCurrentSynchronizationContext());
	    }
	    Console.WriteLine("End of Main");
	    Console.ReadKey();
	}
