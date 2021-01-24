    bool Example()
    {
    	var source = GetLongSequence();
    	
    	var conditions = new List<IEvaluate<int>>
    	{
    		new AnyDivisibleBy(28_413_803),
    		new AllLessThan(99_999_999),
    		new AverageGreaterThan(50_000_001)
    	};
    	
    	foreach (var item in source)
    	{
    	    foreach (var condition in conditions)
    		{
    		    condition.Evaluate(item);
    		}
    	}
    	
        foreach (var condition in conditions)
    	{
    	    if (!condition.Result)
    			return false;
    	}
    	return true;	
    }
    
    static IEnumerable<int> GetLongSequence()
    {
        var random = new Random();
        for (long i = 0; i < 10_000_000_000; i++) yield return random.Next(0, 100_000_000);
    }
    
    interface IEvaluate<T>
    {
        void Evaluate(T item);
    	bool Result { get; }
    }
    
    class AnyDivisibleBy : IEvaluate<int>
    {
    	private bool _result;
    	private readonly int _divisor;
    	public AnyDivisibleBy(int divisor)
    	{
    		_divisor = divisor;
    		_result = false;
    	}
    	
        public void Evaluate(int item)
    	{
    		if (item % _divisor == 0)
    		{
    			_result = true;
    		}
    	}
    		
    	public bool Result => _result;
    }
    
    
    class AllLessThan : IEvaluate<int>
    {
    	private bool _result;
    	private readonly int _limit;
    	public AllLessThan(int limit)
    	{
    		_limit = limit;
    		_result = true;
    	}
    	
        public void Evaluate(int item)
    	{
    		if (item >= _limit)
    		{
    			_result = false;
    		}
    	}
    		
    	public bool Result => _result;
    }
    
    
    class AverageGreaterThan : IEvaluate<int>
    {
    	private long _sum;
    	private int _count;
    	private readonly int _limit;
    	public AverageGreaterThan(int limit)
    	{
    		_limit = limit;
    	}
    	
        public void Evaluate(int item)
    	{
    		_sum += item;
    		_count++;
    	}
    		
    	public bool Result => _sum / _count > _limit;
    }
