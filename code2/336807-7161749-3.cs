	void updateAvgBuyPrice()
	{
		lock(AvgBuyPriceLocker)
		{
			float oldPrice = AvgBuyPrice;
			float newPrice = oldPrice + <Some other code here>
			//Some more new price calculation here
			AvgBuyPrice = newPrice;
		}
	}
