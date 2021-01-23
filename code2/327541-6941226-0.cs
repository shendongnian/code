		var grps =
			from p in products
			group p by new
			{
				p.Product,
				p.Origin_Year,
			} into g
			let lookup = g.ToLookup(x => x.DY, x => x.Incremental_Value)
			select new
			{
				g.Key.Product,
				g.Key.Origin_Year, 
				DYs = dys.Select(x => lookup[x].Sum()).ToArray(),
			};
