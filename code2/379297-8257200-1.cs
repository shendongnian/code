            var query = from x in list
                        group x by x.Item1 into g
                        let sum = g.Sum(x => x.Item2)
                        let poids = g.Sum(x => x.Item3)
                        let remainder = sum % limCol
                        let items = Enumerable.Repeat(limCol, sum / limCol).Concat(Enumerable.Repeat(remainder, remainder > 0 ? 1 : 0))
                        select new
                        {
                            Key = g.Key,
                            Items = items,
                            CalculPoids = poids / items.Count()
                        };
            var result = query.SelectMany(p => p.Items.Select(i => Tuple.Create(p.Key, i, p.CalculPoids)));
