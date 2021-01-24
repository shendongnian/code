    class MyEventHandler
	{
		private object _lockObject;
		
		MyEventHandler()
		{
			_lockObject = new object();
		}
		public int MyContestedResource { get; }
		
		public void HandleEvent( object sender, MyEvent event )
		{
			lock ( _lockObject )
			{
				// do stuff with event here
				MyContestedResource++;
			}
		}
	}
