    private static ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim();
---
    [HttpGet]
    public Task<IActionResult> FetchAlarmsListAsync()
    {
		cacheLock.EnterReadLock();
		try
		{
			// Enumeration is thread-safe in Dictionary.
			foreach (var item in AlarmEngine.normalDictionary)
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
	
