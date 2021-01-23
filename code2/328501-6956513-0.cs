	ExecuteWithRetry (delegate {
		// retry the whole connection attempt each time
		HttpWebRequest request = ...;
		response = request.GetResponse();
		...
	});
	private void ExecuteWithRetry (Action action) {
		// Use a maximum count, we don't want to loop forever
		// Alternativly, you could use a time based limit (eg, try for up to 30 minutes)
		const int maxRetries = 5;
		bool done = false;
		int attempts = 0;
		while (!done) {
			attempts++;
			try {
				action ();
				done = true;
			} catch (WebException ex) {
				if (!IsRetryable (ex)) {
					throw;
				}
				if (attempts >= maxRetries) {
					throw;
				}
				// Back-off and retry a bit later, don't just repeatedly hammer the connection
				Thread.Sleep (SleepTime (attempts));
			}
		}
	}
	private int SleepTime (int retryCount) {
		// I just made these times up, chose correct values depending on your needs.
		// Progressivly increase the wait time as the number of attempts increase.
		switch (retryCount) {
			case 0: return 0;
			case 1: return 1000;
			case 2: return 5000;
			case 3: return 10000;
			default: return 30000;
		}
	}
	private bool IsRetryable (WebException ex) {
		return
			ex.Status == WebExceptionStatus.ReceiveFailure ||
			ex.Status == WebExceptionStatus.ConnectFailure ||
			ex.Status == WebExceptionStatus.KeepAliveFailure;
	}
