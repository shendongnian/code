	class OpponentTeam
	{
		private int mana = 0;
		// The event handler for each instance
		public void OnNetworkMessageReceived(string message, dynamic args)
		{
			switch (message)
			{
				case "MOVE_OPPONENT": { UpdateMana(args); } break;
				// TODO: Add additional network messages here.
			}
		}
		private void UpdateMana(dynamic args)
		{
			mana = args.Mana;
		}
	}
