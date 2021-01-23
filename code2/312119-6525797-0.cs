    bool IsServerUp()
    {
        var x = new Ping();
        var reply = x.Send(IPAddress.Parse("127.0.0.1"));
    
	if (reply == null) return false;
	
	return reply.Status == IPStatus.Success ? true : false;
    } 
    int? GetStatusId()
    {
	try	
	{
		using (var statusRepository = new  StatusRepositoryClient.StatusRepositoryClient())
		{
			return statusRepository.GetIdByName(licencePlateSeen.CameraId.ToString());
		}
	}catch(TimeoutException te)
	{
		//Log TimeOutException occured
		return null;
	}
    }
    void GetStatus()
    {
	try
	{
		TimeSpan sleepTime = new TimeSpan(0,0,5);
		int maxRetries = 10;
	
		while(!IsServerUp())
		{
			System.Threading.Thead.Sleep(sleepTime);
		}
	
		int? statusId = null;
		int retryCount = 0;
		
		while (!statusId.HasValue)
		{
			statusId = GetStatusId();
			retryCount++;
			
			if (retryCount > maxRetries)
				throw new ApplicationException(String.Format("{0} Maximum Retries reached in order to get StatusId", maxRetries));
			System.Threading.Thead.Sleep(sleepTime);
		}
	}catch(Exception ex)
	{
		//Log Exception Occured
	}
    } 
