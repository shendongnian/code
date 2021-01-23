    public static class MyClass
	{
	    public static void MyFunction(MyObject messageReceived )
		{
			// Call this stuff from non-gui thread.
		    SynchronizationContext syncContext = SynchronizationContext.Current;
			syncContext.Send(MyMethod, param);
			
			// You can also use SyncContext.Post if you don't need to wait for completion.
			syncContext.Post(MyMethod, param);
		}
		
		private static void MyMethod(object state)
		{
			MyObject myObject = state as MyObject;
			... do my stuff into the gui thread.
		}
		
		// Using anonymous delegates you can also have a return value using Send.
		public static int MyFunctionWithReturnValue(MyObject parameter)
		{
			int result = 0;
			SynchronizationContext.Current.Post(delegate (object p)
			{
				result = parameter.DoSomething()
			}, null);
			
			return result;
		}
	}
