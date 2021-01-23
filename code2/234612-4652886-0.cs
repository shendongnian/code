		// Inspired by: http://aspalliance.com/72
		const string ViewStateFieldName = "__VIEWSTATEKEY";
		const string ViewStateKeyPrefix = "ViewState_";
		const string RecentViewStateQueue = "ViewStateQueue";
		const int RecentViewStateQueueMaxLength = 5;
		protected override object LoadPageStateFromPersistenceMedium()
		{
			// The cache key for this viewstate is stored in a hidden field, so grab it
			string viewStateKey = Request.Form[ViewStateFieldName] as string;
			if (viewStateKey == null) return null;
			// Grab the viewstate data using the key to look it up
			return Session[viewStateKey];
		}
		protected override void SavePageStateToPersistenceMedium(object viewState)
		{
			// Give this viewstate a random key
			string viewStateKey = ViewStateKeyPrefix + Guid.NewGuid().ToString();
			// Store the viewstate
			Session[viewStateKey] = viewState;
			// Store the viewstate's key in a hidden field, so on postback we can grab it from the cache
			ClientScript.RegisterHiddenField(ViewStateFieldName, viewStateKey);
			// Some tidying up: keep track of the X most recent viewstates for this user, and remove old ones
			var recent = Session[RecentViewStateQueue] as Queue<string>;
			if (recent == null) Session[RecentViewStateQueue] = recent = new Queue<string>();
			recent.Enqueue(viewStateKey); // Add this new one so it'll get removed later
			while (recent.Count > RecentViewStateQueueMaxLength) // If we've got lots in the queue, remove the old ones
				Session.Remove(recent.Dequeue());
		}
