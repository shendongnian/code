	private void OnRefreshRequested()
	{
		//make sure the event is being listened to. no point raising an event if no one cares!
		if (this.RefreshRequested != null)
		{
			this.RefreshRequested(this, EventArgs.Empty);
		}
	}
