            var result = list
                .GroupBy(x => x.Item1)
                .Select(g => new
                {
                    Key = g.Key,
                    Sum = g.Sum(x => x.Item2),
                    Poids = g.Sum(x => x.Item3),
                })
                .Select(p => new
                {
                    Key = p.Key,
                    Items = Enumerable.Repeat(limCol, p.Sum / limCol).Concat(Enumerable.Repeat(p.Sum % limCol, p.Sum % limCol > 0 ? 1 : 0)),
                    CalculPoids = p.Poids / Enumerable.Repeat(limCol, p.Sum / limCol).Concat(Enumerable.Repeat(p.Sum % limCol, 1)).Count()
                })
                .SelectMany(p => p.Items.Select(i => Tuple.Create(p.Key, i, p.CalculPoids)))
                .ToList();
