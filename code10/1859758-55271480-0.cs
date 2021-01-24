c-sharp
void Insert(IEnumerable<Transaction> data)
        {
            using(var context = dbContextFactory.CreateDbContext(new string[0]))
            {
                List<Stock> stocks = data.Select(s => s.RelatedStock).Distinct(new StockComparer()).ToList();
                context.AddRange(stocks);
                context.SaveChanges();
                stocks = context.Stocks.ToList();
                List<Transaction> newList = new List<Transaction>(data.Count());
                foreach (var t in data)
                {
                        Stock relatedStock = stocks.Where(s => s.Name == t.RelatedStock.Name).First();
                        t.RelatedStock = relatedStock;
                        newList.Add(t);
                }
                context.Transactions.AddRange(newList);
                context.SaveChanges();
            }
        }
