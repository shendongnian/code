    		protected override void OnSessionChange(SessionChangeDescription changeDescription)
		{
			base.OnSessionChange(changeDescription);
			switch (changeDescription.Reason)
			{
				case SessionChangeReason.SessionLogon:
                                    // do your logging here
					break;
				case SessionChangeReason.SessionLogoff:
                                    // do your logging here
					break;
			}
		}
