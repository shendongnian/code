	private volatile int TradesCount;
	private List<...> Trades;
	void MyFunction()
	{
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
		if (count >= Trades.Count)
		{
			count = Trades.Count;
			timer1.Enabled = false;
		}
		progressBarTrades.Value = (100 * count) / Trades.Count;
		buttonAction.Text = count.ToString();
	}
	
	private void CheckTradeOneForOne()
	{
		int current;
		for (;;)
		{
			// This will give you a warning, but you can ignore it with a #pragma, it is allowed to use Interlocked.Increment and volatile fields.
			current = Interlocked.Increment(ref TradesCount) - 1;
			
			if (current >= Trades.Count)
				break; // We can exit the loop.
			temppage = HelpClass.GetSourceCodeForTrade(Trades[current], sessid, profilenum);
			//if the trainer has requested anything?
			if (!HelpClass.RequestAnything(temppage))
			{
				...
			}
		}
	}
