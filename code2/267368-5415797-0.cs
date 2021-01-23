	progressBar1.Minimum = 1;
	progressBar1.Maximum = this._StockListToProcess.Count;
	
	var itemsProcessed = 0;
	var updater = new Subject<Unit>(Scheduler.Dispatcher);
	updater.Subscribe(u =>
	{
		itemsProcessed += 1; //Rx serializes "OnNext" calls so this is safe.
		progressBar1.Value = itemsProcessed;
	});
	
	Parallel.ForEach(this._StockListToProcess, new ParallelOptions() { MaxDegreeOfParallelism = 5 },
		(Stock stock) =>
			{
				MyWebServiceClient serviceClient = new MyWebServiceClient ();
				MyWebServiceClient.ResponseEnum result = (MyWebServiceClient .ResponseEnum)serviceClient.SetProductPricing(token.LoginName, token.LoginPassword, token.SiteID.ToString(), stock.ProductCode, stock.ProductPrice);
				updater.OnNext(new Unit());
			});
	updater.OnCompleted();
