    IEnumerable<A> result = (from a in A join b in B on a.id equals b.id_A
                             group b by b.id_A into g
                             select new
                             {
                                 Name = a.name,
                                 Total = g.Sum(b => b.quantity)
                             })
                            .ToArray()
                            .Select(item => new A
                            {
                                Name = item.Name,
                                TotalQuantity = item.Total
                            });
