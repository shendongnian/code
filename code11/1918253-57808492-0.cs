	var query = 
		from sd in Stockdiaries
		join loc in Locations on sd.Location equals loc.Id
		// This is a cross join, so just add 'from' with no 'on' logic
		from prod in Products 
		// This is a left join.  So you've got to do the into hoop and 
		// then 'overwrite' the 'cat' table.
		join cat in Categories on prod.Category equals cat.Id into pCat
		from cat in pCat.DefaultIfEmpty()
		
		// put it all together into one result set
		select new {
			Location = loc.Name,
		    Category = cat?.Name, // Because it's a left join, it may be null, hence the '?'
		    Reference = prod.Reference,
		    Product = prod.Name,
			sd.Units,
			sd.Price
		
		} into cnd
				
        // group as appropriate, and remember that in linq 
        // grouping is a separate operation from aggregation
		group cnd by new { cnd.Location, cnd.Reference, cnd.Product, cnd.Category } into g
		
        // aggregate as appropriate
		select new {
			g.Key.Location,
			g.Key.Reference,
			g.Key.Product,
			g.Key.Category,
			UnitsOut = g.Sum(row => row.Units < 0 ? row.Units : 0),
			TotalOut = g.Sum(row => row.Units < 0 ? row.Units * row.Price : 0),
			UnitsIn = g.Sum(row => row.Units >= 0 ? row.Units : 0),
			TotalIn = g.Sum(row => row.Units >= 0 ? row.Units * row.Price : 0),
			UnitsDiff = g.Sum(row => row.Units),
			TotalDiff = g.Sum(row => row.Units * row.Price)
		};
				
	query.Dump();
