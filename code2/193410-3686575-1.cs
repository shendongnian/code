    protected void FetchingRates()
    {
        int ratesInterval = int.Parse(ConfigurationManager.AppSettings["RatesIntreval"].ToString());
    	int count = 0;
    	var queue = new WorkQueue<RateLog>();
    
    	while (true)
    	{
    		try
    		{
    			var items = default(RateLog[]);
    			if (queue.TryGet(out items))
                {
    				foreach (var item in items)
    				{
    					m_ConnectionDataAccess.InsertRateLog(item);
    				}
                }
    		}
    		catch (Exception ex)
    		{  
    			Logger.Log(ex);                 
    		}
              
            Thread.Sleep(ratesInterval);
            count++;
    	}
    } 
