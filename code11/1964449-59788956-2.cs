    class NetworkCode
	{
		private Dictionary<string, Tuple<OpponentTeam, MethodInfo>> registrations = new Dictionary<string, Tuple<OpponentTeam, MethodInfo>>();
		public void Register(string msg, OpponentTeam team, MethodInfo method)
		{
			if (!registrations.ContainsKey(msg))
			{
				registrations[msg] = new Tuple<OpponentTeam, MethodInfo>(team, method);
			}
		}
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
			Tuple<OpponentTeam, MethodInfo> registration = registrations["MOVE_OPPONENT"];
			registration.Item2.Invoke(registration.Item1, new[] { args });
		}
	}
