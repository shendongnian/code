	var dupes = recs
	.Select(r => new
	{
		r.From,
		r.To,
		DuplicateClusters = r.REC_Clusters.GroupBy(c => c)
              .Where(g => g.Count() > 1) // duplicates
              .SelectMany(g => g)  // flatten it back
              .ToArray() // indexed
	})
	.Where(r => r.DuplicateClusters.Any()) //only interested in clusters with duplicates
    .ToArray();
