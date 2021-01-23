	void Start()
	{
		System.IO.Stream s = ...;
		byte[] buf = ...;
		// start the IO.
		s.BeginRead(buf, 0, buf.Length, res =>
			{
				// this gets called when it's finished,
				// but you're in a different thread.
				
				int len = s.EndRead(res);
				
				// so you must call Dispatcher.Invoke
				// to get back to the UI thread.
				
				Dispatcher.Invoke((Action)delegate
					{
						// perform UI updates here.
					});
			}, null);
			 
		// the IO is started (and maybe finished) here,
		// but you probably don't need to put anything here.
	}
