    try
	{
		// Synchronize
		syncStats = syncAgent.Synchronize();
		App.SyncStats = syncStats;
	}
	catch (SyncException exception)
	{
		if (exception.Message.Contains(" Unable to obtain a new server anchor."))
		{                    
			syncSnapShotStats = syncSnapShotAgent.Synchronize();
			App.SyncStats = syncSnapShotStats;
		}
		else
		{
			throw;
		}
	}
