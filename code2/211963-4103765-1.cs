    private readonly IDictionary<string,int> mDictionary = new Dictionary<string, int>();
    
    public void IncrementCounter(string counterKey)
    {
    	if(mDictionary.ContainsKey(counterKey))
    	{
    		int existingCount = mDictionary[counterKey];
    
    		mDictionary[counterKey] = existingCount + 1;
    	}
    	else
    	{
    		mDictionary.Add(counterKey, 1);
    	}
    }
    
    public void TryIncrementCounter(string counterKey)
    {
    	int existingCount;
    	if (mDictionary.TryGetValue(counterKey, out existingCount))
    	{
    		mDictionary[counterKey] = existingCount + 1;
    	}
    	else
    	{
    		mDictionary.Add(counterKey, 1);
    	}
    }
