	public MainViewModel()
	{
		var rng = new Random();
		var timer = new DispatcherTimer();
		timer.Interval = TimeSpan.FromSeconds(0.1);
		timer.Tick += (s, e) =>
		{
			var row = this.PriceLevels[rng.Next(this.PriceLevels.Count())]; // get random row
			switch (rng.Next(4))
			{
				case 0: row.BuyOrders.Add(1 + rng.Next(5)); break;
				case 1: row.SellOrders.Add(1 + rng.Next(5)); break;
				case 2: if (row.BuyOrders.Count() > 0) row.BuyOrders.RemoveAt(rng.Next(row.BuyOrders.Count())); break;
				case 3: if (row.SellOrders.Count() > 0) row.SellOrders.RemoveAt(rng.Next(row.SellOrders.Count())); break;
			}
		};
		timer.Start();
	}
