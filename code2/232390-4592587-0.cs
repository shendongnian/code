    public sealed class DateTimeFloatDictionary : IEnumerable<KeyValuePair<DateTime, float>>
    {
    	private readonly Dictionary<DateTime, float> _dictionary;
    
    	public float this[DateTime index]
    	{
    		get
    		{
    			return _dictionary[index.Date];
    		}
    		set
    		{
    			_dictionary[index] = value;
    		}
    	}
    
    	public DateTimeFloatDictionary()
    	{
    		_dictionary = new Dictionary<DateTime, float>();
    	}
    
    	public bool Contains(DateTime time)
    	{
    		return _dictionary.ContainsKey(time.Date);
    	}
    
    	public void Add(DateTime time, float value)
    	{
    		_dictionary.Add(time.Date, value);
    	}
    
    	public bool Remove(DateTime time)
    	{
    	    return _dictionary.Remove(time.Date);
    	}
    	#region IEnumerable<KeyValuePair<DateTime,float>> Members
    
    	public IEnumerator<KeyValuePair<DateTime, float>> GetEnumerator()
    	{
    		return _dictionary.GetEnumerator();
    	}
    
    	#endregion
    
    	#region IEnumerable Members
    
    	System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    	{
    		return this.GetEnumerator();
    	}
    
    	#endregion
    }
