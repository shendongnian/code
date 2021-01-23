    var query = list.GroupBy(x => x.Title)
                    .Select(group =>
                    {
                        decimal maxPrice = group.Max(x => x.Price);
                        return group.Where(x => x.Price == maxPrice)
                                    .First();
                    };
