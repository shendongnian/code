    void Main()
    {
    	var deck = new ConcurrentDeck<Tuple<string,DateTime>>(25);
    	var handle = new ManualResetEventSlim();
    	var task1 = Task.Factory.StartNew(()=>{
    	var timer = new System.Timers.Timer();
    	timer.Elapsed += (s,a) => {deck.Push(new Tuple<string,DateTime>("task1",DateTime.Now));};
    	timer.Interval = System.TimeSpan.FromSeconds(1).TotalMilliseconds;
    	timer.Enabled = true;
    	handle.Wait();
    	});	
    	var task2 = Task.Factory.StartNew(()=>{
    	var timer = new System.Timers.Timer();
    	timer.Elapsed += (s,a) => {deck.Push(new Tuple<string,DateTime>("task2",DateTime.Now));};
    	timer.Interval = System.TimeSpan.FromSeconds(.5).TotalMilliseconds;
    	timer.Enabled = true;
    	handle.Wait();
    	});	
    	var task3 = Task.Factory.StartNew(()=>{
    	var timer = new System.Timers.Timer();
    	timer.Elapsed += (s,a) => {deck.Push(new Tuple<string,DateTime>("task3",DateTime.Now));};
    	timer.Interval = System.TimeSpan.FromSeconds(.25).TotalMilliseconds;
    	timer.Enabled = true;
    	handle.Wait();
    	});	
    	System.Threading.Thread.Sleep(TimeSpan.FromSeconds(10));
    	handle.Set();
    	var outputtime = DateTime.Now;
    	deck.ReadDeck().Select(d => new {Message = d.Item1, MilliDiff = (outputtime - d.Item2).TotalMilliseconds}).Dump(true);
    }
