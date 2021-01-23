    protected void FetchingRates()
    {
      int count = 0;
      List<RateLog> temp = new List<RateLog>();
    
      while (true)
      {
        try
        {
          if (m_RatesQueue.Count > 0)
          {    
            lock (m_RatesQueue)
            {
              temp.AddRange(m_RatesQueue);
              m_RatesQueue.Clear();
            }
    
            foreach (RateLog item in temp)
            {
              m_ConnectionDataAccess.InsertRateLog(item);
            }
    
            temp.Clear();
          }
          count++;
          Thread.Sleep(int.Parse(ConfigurationManager.AppSettings["RatesIntreval"].ToString()));
        }
        catch (Exception ex)
        {                   
        }
      }
    } 
