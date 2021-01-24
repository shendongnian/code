	items
		.ToList()
		.ConvertAll(x => 
			new BlessingDTO()
			{
				BlessingCategoryName = x.ToList().Select(y => y.MessageName).Distinct().ToList(),
				Blessings = x.ToList().Select(y => y.MessageText).ToList()
			}
		);
