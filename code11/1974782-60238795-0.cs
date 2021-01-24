    private static ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim();
---
    [HttpGet]
    public Task<IActionResult> FetchAlarmsListAsync()
    {
		cacheLock.EnterReadLock();
		try
		{
			// Enumeration is thread-safe in ConcurrentDictionary.
			foreach (var item in AlarmEngine.concurrentDictionary)
			{
				// How do I access the key and value pairs here?
				// Note each value contains a subset of items
				// i want to access all items stored
			}
			return new JsonResult(Array containing all keys and value items);
		}
		finally
		{
			cacheLock.ExitReadLock();
		}
    }
	
