    from market in _context.Markets
    where market.TypeId == 1
    from exchange in market.Exchanges
    join lastExchange in _context.Exchanges
    	.GroupBy(e => e.MarketId)
    	.Select(g => new { MarketId = g.Key, Date = g.Max(e => e.LastUpdatedDateTime) })
    on new { exchange.MarketId, Date = exchange.LastUpdatedDateTime }
    equals new { lastExchange.MarketId, lastExchange.Date }
    select new DtoGetAllMarketsWithLastExchanges
    {
    	Id = market.Id,
    	Code = market.Code,
    	Name = market.Name,
    	LastBuyPrice = exchange.LastBuyPrice,
    	LastSellPrice = exchange.LastSellPrice,
    	SeoUrl = market.SeoUrl,
    	Icon = market.Icon,
    	LastUpdateDate = exchange.LastUpdatedDateTime,
    	Rate = exchange.Rate
    }
