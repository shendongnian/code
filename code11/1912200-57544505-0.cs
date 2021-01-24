    from market in _context.Markets
    where market.TypeId == 1
    from exchange in market.Exchanges
    where exchange.LastUpdatedDateTime == market.Exchanges.Max(e => (DateTime?)e.LastUpdatedDateTime)
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
