	cacheLock.EnterWriteLock();
	try
	{
		concurrentDictionary.TryAdd(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), new Alarm 
		{
			DateTimeActivated = DateTime.Now,
			ApplicationRoleId = applicationRoleId,
			AlarmId = alarmId,
			AlarmName = alarmName,
			AlarmDescription = description,
		}); // I'm using datetime as the key as this is unique form each key/value pair added.
	}
	finally
	{
		cacheLock.ExitWriteLock();
	}
