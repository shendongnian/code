cs
var query = listModel.GroupBy(i => new {i.ClassId, i.Gender})
	.OrderBy(g => g.Key.ClassId)
	.ThenBy(g => g.Key.Gender)
	.SelectMany(g => g, (g, item) => new
	{
		g.Key.ClassId,
		g.Key.Gender,
		item.Name,
		Count = g.Count(),
		MaxAge = g.Max(i => i.Age),
		MinAge = g.Min(i => i.Age)
	});
