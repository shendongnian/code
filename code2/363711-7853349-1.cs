    public static IsTrue(Func<bool> condition, TimeSpan timeout)
    {
    	if (!SpinWait.SpinUntil(condition, timeout))
    	{
    		Assert.IsTrue(condition);
    	}
    }
