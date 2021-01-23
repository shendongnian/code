	var t = new System.Threading.Thread(new ThreadStart(() =>
	{
		foreach (var c in controls)
		{
			this.Invoke(new Action(() => c.Visible = true));
			// Thread.Sleep(100); // Slow it down if you wish...
		}
	}));
	t.Start();
