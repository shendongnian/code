    class Foo
    {
    	private IObservable<int> observable;
    	private Queue<int> buffer = new Queue<int>();
    
    	public Foo(IObservable<int> bar)
    	{
    		this.observable = bar;
    			
    		this.observable
    			.Subscribe(item =>
    			{
    				lock (buffer)
    				{
    					if (buffer.Count == 20) buffer.Dequeue();
    					buffer.Enqueue(item);
    				}
    			});
    	}
    
    	public IEnumerable<int> MostRecentBars
    	{
    		get
    		{
    			lock (buffer)
    			{ 
    				return buffer.ToList();		// Create a copy.
    			}
    		}
    	}
    }
