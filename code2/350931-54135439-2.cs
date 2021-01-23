    ReadOnlyObservableCollection<TradeProxy> list;
    var myTradeCache = new SourceCache<Trade, long>(trade => trade.Id);
    var myOperation = myTradeCache.Connect() 
    		.Filter(trade=>trade.Status == TradeStatus.Live) 
    		.Transform(trade => new TradeProxy(trade))
    		.Sort(SortExpressionComparer<TradeProxy>.Descending(t => t.Timestamp))
    		.ObserveOnDispatcher()
    		.Bind(out list) 
    		.DisposeMany()
    		.Subscribe()
