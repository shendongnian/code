	    static async Task Main(string[] args)
	    {
		    try
		    {
			    var f = new TaskFactory(TaskScheduler.Current);
			    await await f.StartNew(async () =>
			    {
				    var x = 0;
				    if (x == 0)
					    throw new Exception("we have a problem");
				    await Task.Delay(1);
			    });
		    }
		    catch(Exception)
		    {
			    Console.WriteLine("Exception received");
			    // never reaches here
		    }
		    Console.WriteLine("Done");
	    }
