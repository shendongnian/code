    bool Example()
    {
    	var source = GetLongSequence();
    	
    	var conditions = new List<IEvaluate<int>>
    	{
			new Any<int>(n => n % 28_413_803 == 0),
			new All<int>(n => n < 99_999_999),
			new Average(d => d > 50_000_001)
    	};
    	
    	foreach (var item in source)
    	{
    	    foreach (var condition in conditions)
    		{
    		    condition.Evaluate(item);
    		}
    	}
    	
    	return conditions.All(c => c.Result);	
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
	
	class Any<T> : IEvaluate<T>
	{
		private bool _result;
		private readonly Func<T, bool> _predicate;
		
		public Any(Func<T, bool> predicate)
		{
			_predicate = predicate;
			_result = false;
		}
		
	    public void Evaluate(T item)
		{
			if (_predicate(item))
			{
				_result = true;
			}
		}
			
		public bool Result => _result;
	}
	
	
	class All<T> : IEvaluate<T>
	{
		private bool _result;
		private readonly Func<T, bool> _predicate;
		
		public All(Func<T, bool> predicate)
		{
			_predicate = predicate;
			_result = true;
		}
		
	    public void Evaluate(T item)
		{
			if (!_predicate(item))
			{
				_result = false;
			}
		}
			
		public bool Result => _result;
	}
	
	class Average : IEvaluate<int>
	{
		private double _sum;
		private int _count;
		Func<double, bool> _evaluate;
		public Average(Func<double, bool> evaluate)
		{
		}
		
	    public void Evaluate(int item)
		{
			_sum += item;
			_count++;
		}
			
		public bool Result => _evaluate(_sum / _count);
	}
