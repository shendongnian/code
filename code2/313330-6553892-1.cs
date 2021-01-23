	static void Main(string[] args)
	{
	    //this class is from the Understanding SynchronizationContext. 
	    StaSynchronizationContext context = new StaSynchronizationContext();
	    Debug.WriteLine("Starting on {0}", Thread.CurrentThread.ManagedThreadId);
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
	            Debug.WriteLine("Done {0} on {1}", num, Thread.CurrentThread.ManagedThreadId);
	            return num;
	        }).ContinueWith(
	        value =>
	        {
	            context.Send((o) => Debug.WriteLine("Completed {0} on {1}", value.Result, Thread.CurrentThread.ManagedThreadId), null);
	        }
	       );
	    }
	    Console.WriteLine("End of Main");
	    Console.ReadKey();
	}
