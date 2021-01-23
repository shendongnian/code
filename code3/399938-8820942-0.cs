	private readonly object mLock = new object();
	public void FirstMethod()
	{
		while (/* Running some operations */)
		{
			// Get the lock
			lock (mLock)
			{
				// Add to the dictionary
				mSomeDictionary.Add("Key", "Value");
			}
		}
	}
	public void SecondMethod()
	{
		while (/* Running some operation */)
		{
			// Get the lock
			lock (mLock)
			{
				// Remove from dictionary
				mSomeDictionary.Remove("Key");
			}
		}
	}
