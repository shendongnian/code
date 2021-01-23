        items
            .Where(x => x.Closed == null)
            .Select(x =>
                new Item
                {
                    Closed = x.Closed,
                    Opened = x.Opened,
                    Prices = new List<Price>(x.Prices.Where(p => p.Closed == null))
                });
