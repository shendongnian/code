	class NetworkCode
	{
		// The multi-cast event that many instances can attach to and be notified
		public event NetworkMessageReceivedHandler NetworkMessageReceived;
		public void OnReceiveMessageTest()
		{
			// simulate the callback from the server
			dynamic args = new ExpandoObject();
			args.Mana = 10;
			args.Path = new List<Point>
			{
				new Point { X = 0, Y = 0 },
				new Point { X = 1, Y = 0 },
				new Point { X = 1, Y = 1 }
			};
			// Check to see if any code has registered for this event
			if (NetworkMessageReceived != null)
			{
				// Assuming "MOVE_OPPONENT" is a message from the server
				NetworkMessageReceived("MOVE_OPPONENT", args);
			}
		}
	}
