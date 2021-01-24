    dogList = dogList
		.GroupBy(d => d.Name)
		.Select(dogGroup =>
		{
			Dog latestDog = dogGroup.OrderByDescending(d => d.ImportDate).First();
			if (!latestDog.Price.HasValue)
			{
				latestDog.Price = dogGroup
                    .FirstOrDefault(dog => dog.Price.HasValue)?.Price.Value ?? null;
			}
			return latestDog;
		})
		.ToList();
