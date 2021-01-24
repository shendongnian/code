     var r = (from t in trades
            group t by new { t.AccountId }
            into g
            select new AccountManagerAccountModel()
            {
                AccountId = g.Key.AccountId,
                AccountName = g.Key.AccountId,
                Securities = g.GroupBy(c1=> new {c1.AccountId, c1.SecurityId, c1.TradeType}).Select(c2=> new AccountStockModel()
                {
                    AccountId = c2.Key.AccountId,
                    SecurityId = c2.Key.SecurityId,
                    TradeType = c2.Key.TradeType.First().Equals("NORMAL") ? "It is a Normal Trade" : c2.Key.TradeType.First().Equals("EQ-NEG") ? "It is a EQ-NEG Trade" : String.Format("It is a {0} Trade", c2.Key.TradeType),
                    Trades = c2.Count(),
                    Quantity = c2.Sum(s=>s.Qty),
                    Turnover = c2.Sum(s=>s.NetAmount)
                }).ToList()
            }
            ).ToList();
