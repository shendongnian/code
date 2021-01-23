		public static Thread OwnerThread(this Control ctrl)
		{
			Thread activeThread = null;
			if (ctrl.InvokeRequired)
			{
				activeThread = (Thread)ctrl.Invoke(new Func<Control, Thread>(OwnerThread), new object[] { ctrl });
			}
			else
			{
				activeThread = Thread.CurrentThread;
			}
			return activeThread;
		}
