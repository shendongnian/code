      var list = from item in doc.Descendants("client")
                 let tradeinfoelement = item.Element("trade_info")
                 select new
                 {
                   Client = new
                   {
                     Id = (string)item.Element("id"),
                     Name = (string)item.Element("name"),
                     Desc = (string)item.Element("desc")
                   },
                   TradeInfo = new
                   {
                     BuyPrice = tradeinfoelement.Element("buy_price_rate")  != null ? (int?)tradeinfoelement.Element("buy_price_rate") : null,
                     Tabs = tradeinfoelement.Descendants("tab") != null ? tradeinfoelement.Descendants("tab").Select(t => (string)t).ToList() : null
                   }
                 };
