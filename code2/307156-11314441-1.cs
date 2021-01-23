	public static class TransactionmanagerHelper
	{
		public static void OverrideMaximumTimeout(TimeSpan timeout)
		{
			//TransactionScope inherits a *maximum* timeout from Machine.config.  There's no way to override it from
			//code unless you use reflection.  Hence this code!
			//TransactionManager._cachedMaxTimeout
			var type = typeof(TransactionManager);
			var cachedMaxTimeout = type.GetField("_cachedMaxTimeout", BindingFlags.NonPublic | BindingFlags.Static);
			cachedMaxTimeout.SetValue(null, true);
			//TransactionManager._maximumTimeout
			var maximumTimeout = type.GetField("_maximumTimeout", BindingFlags.NonPublic | BindingFlags.Static);
			maximumTimeout.SetValue(null, timeout);
		}
	}
