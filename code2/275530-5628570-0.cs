    void Main()
    {
    	var spooler = new Spooler();
    	Random r = new Random();
    	for (int i = 0; i < 10; i++)
    	{
    		var work = new DoSomeWork { Delay = r.Next(100, 5000) };
    		spooler.Add(work);
    	}
    	spooler.Poll(100);
    	Logger.Log("finish");
    }
    static class Logger
    {
    	internal static void Log(string msg)
    	{
    		Console.WriteLine("{0} says " + msg, Thread.CurrentThread.ManagedThreadId);
    	}
    }
    public class Spooler
    {
    	private object _lock = new object();
    	private List<DoSomeWork> _workItems = new List<DoSomeWork>();
    	public void Add(DoSomeWork work)
    	{
    		_workItems.Add(work);
    		Action whenDone = () => { lock(_lock) work.Done = true; };
    		(new Thread(()=>work.CompleteTask(whenDone))).Start();        
    	}
    	public void Poll(int rate)
    	{
    		while(true)
    		{
    			var q = from c in _workItems
    					where c.Done == false
    					select c;
    			Logger.Log("poll");
    			int count = -1;
    			lock(_lock)
    			{		
    				if(q.FirstOrDefault() == null) break;
    				count = q.Count();
    			}
    			Logger.Log(count + " to go");
    			Thread.Sleep(rate);
    		}
    	}
    }
    public class DoSomeWork
    {
    	public bool Done = false;
    	public int Delay { get; set; }
    	public void CompleteTask(Action whenDone)
    	{
    		Logger.Log("begin " + Delay);
    		Thread.Sleep(Delay);
    		Logger.Log("end");
    		whenDone();
    	}
    }
    15 says begin 2707
    21 says begin 2809
    12 says begin 4586
    27 says begin 4822
    28 says begin 242
    29 says begin 2989
    30 says begin 1374
    31 says begin 4265
    32 says begin 2679
    33 says begin 4041
    14 says poll
    14 says 10 to go
    14 says poll
    14 says 10 to go
    14 says poll
    14 says 10 to go
    28 says end
    14 says poll
    14 says 9 to go
    14 says poll
    14 says 9 to go
    14 says poll
    14 says 9 to go
    14 says poll
    14 says 9 to go
    14 says poll
    14 says 9 to go
    14 says poll
    14 says 9 to go
    14 says poll
    14 says 9 to go
    14 says poll
    14 says 9 to go
    14 says poll
    14 says 9 to go
    14 says poll
    14 says 9 to go
    14 says poll
    14 says 9 to go
    30 says end
    14 says poll
    14 says 8 to go
    14 says poll
    14 says 8 to go
    14 says poll
    14 says 8 to go
    14 says poll
    14 says 8 to go
    14 says poll
    14 says 8 to go
    14 says poll
    14 says 8 to go
    14 says poll
    14 says 8 to go
    14 says poll
    14 says 8 to go
    14 says poll
    14 says 8 to go
    14 says poll
    14 says 8 to go
    14 says poll
    14 says 8 to go
    14 says poll
    14 says 8 to go
    14 says poll
    14 says 8 to go
    32 says end
    14 says poll
    14 says 7 to go
    15 says end
    14 says poll
    14 says 6 to go
    21 says end
    14 says poll
    14 says 5 to go
    29 says end
    14 says poll
    14 says 4 to go
    14 says poll
    14 says 4 to go
    14 says poll
    14 says 4 to go
    14 says poll
    14 says 4 to go
    14 says poll
    14 says 4 to go
    14 says poll
    14 says 4 to go
    14 says poll
    14 says 4 to go
    14 says poll
    14 says 4 to go
    14 says poll
    14 says 4 to go
    14 says poll
    14 says 4 to go
    14 says poll
    14 says 4 to go
    33 says end
    14 says poll
    14 says 3 to go
    14 says poll
    14 says 3 to go
    31 says end
    14 says poll
    14 says 2 to go
    14 says poll
    14 says 2 to go
    14 says poll
    14 says 2 to go
    12 says end
    14 says poll
    14 says 1 to go
    14 says poll
    14 says 1 to go
    14 says poll
    14 says 1 to go
    27 says end
    14 says poll
    14 says finish
