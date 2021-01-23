	private int TradesCount;
	private List<...> Trades;
	void MyFunction()
	{
		myContext = SynchronizationContext.Current;
		List<Thread> threads = new List<Thread>();
		for (int i = 0; i < 5; i++)
			threads.Add(new Thread(CheckTradeOneForOne));
		timer1.Enabled = true;
		progressBarTrades.Value = 0;
		this.TradesCount = 0;
		foreach (Thread t in threads)
			t.Start();
	}
	
	void timer1_Tick(object sender, EventArgs e)
	{
		int count = this.TradesCount;
		progressBarTrades.Value = (100 * count) / Trades.Count;
		buttonAction.Text = count.ToString();
	}
	
	private void CheckTradeOneForOne()
	{
		int current;
		while (count < Trades.Count)
		{
			current = Interlocked.Increment(count) - 1;
			temppage = HelpClass.GetSourceCodeForTrade(Trades[current], sessid, profilenum);
			//if the trainer has requested anything?
			if (!HelpClass.RequestAnything(temppage))
			{
				...
			}
		}
	}
