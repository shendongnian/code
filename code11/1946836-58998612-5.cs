    private List<MarketTrade> GetTrades()
        {
            List<MarketTrade> lstMarketTrades = new List<MarketTrade>();
            for (int i = 0; i < 10; i++)
            {
                lstMarketTrades.Add(new MarketTrade()
                {
                    Amount = (i + 1) * 4,
                    Dir = i / 2 == 0 ? Direction.Buy : Direction.Sell,
                    Price = (i + 1) * 2,
                    TradeSeq = i
                });
            }
            return lstMarketTrades;
        }
