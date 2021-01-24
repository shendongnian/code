		private readonly ApplicationDbContext dbContext;
		public StockController(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public IActionResult Index()
		{
			var symbol = "MSFT";
			var name = "Microsoft";
			Product product;
			product = dbContext.Products.FirstOrDefault(p => p.Symbol == symbol);
			if (product == null)
			{
				dbContext.Add(new Product() { Symbol = symbol, Name = name });
			}
			else
			{
				dbContext.Entry(product).State = EntityState.Modified;
			}
			dbContext.SaveChanges();
			var apiResponse = $"https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol={symbol}&interval=5min&apikey=APIKEY&datatype=csv".GetStringFromUrl();
			var stocks = apiResponse.FromCsv<List<StockData>>().ToList();
			product.Data = stocks;
			foreach (var stock in product.Data)
			{
				var newStock = dbContext.StockData.FirstOrDefault(s => s.ProductId.Equals(product.ProductId));
				if (!dbContext.StockData.Any(s => s.Timestamp.Equals(stock.Timestamp)))
				{
					if (newStock == null)
					{
						dbContext.Add(stock);
					}
					else
					{
						dbContext.Entry(stock).State = EntityState.Modified;
					}
					dbContext.SaveChanges();
				}
			}
			return View(product);
		}
