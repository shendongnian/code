    class Perfmon
    {
    	private readonly Dictionary<string, string> _counters = new Dictionary<string, string>();
    	
    	public Perfmon(params KeyValuePair<string, string>[] knownCounters)
    	{
    		foreach (var knownCounter in knownCounters)
    		{
    			SetCounter(knownCounter.Key, knownCounter.Value);
    		}
    	}	
    	public void SetCounter(string name, string value)
    	{
    		_counters[name] = value;
    	}
    	
    	protected string GetCounterValue(string name)
    	{
    		if (_counters.ContainsKey(name))
    			return _counters[name];
    		else
    			return null;
    	}
    	
    	public string Counter1 { get { return GetCounterValue("Counter1"); } }
    	public string Counter2 { get { return GetCounterValue("Counter2"); } }
    	public string Counter3 { get { return GetCounterValue("Counter3"); } }
    }
