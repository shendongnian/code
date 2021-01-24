	var items = context.Items.AsNoTracking ();
	var imagesDict = await context.Images.AsNoTracking ()
		.GroupBy (img => img.IdItems)
		.ToDictionaryAsync (g => g.Key, g => g.Count ());
	return Json (await items.Select (item => new {
			item = item,
			numImages = imagesDict.GetValueOrDefault (item.IdItems, 0),
		}).ToListAsync ());
