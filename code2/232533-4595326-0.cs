		private static void ActionWithLog(Action before, Action after)
		{
			string methodName = MethodBase.GetCurrentMethod().Name;
			using (LogService log = LogFactory.Create())
			{
				try
				{
					before();
					log.Info(methodName, "Created entity xyz");
					after();
				}
				catch (Exception ex)
				{
					log.Error(methodName, ex.message);
				}
			}
		}
